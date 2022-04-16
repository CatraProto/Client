using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Collections;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Collections;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.Client.Updates.CustomTypes;
using CatraProto.Client.Updates.Enums;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Updates
{
    class UpdateProcessor : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private static readonly MultiValueDictionary<int, UpdateBase> _applyAt = new MultiValueDictionary<int, UpdateBase>();
        private readonly BrowsableQueue<IObject> _updatesQueue = new BrowsableQueue<IObject>();
        private static readonly TimeSpan WaitTime = TimeSpan.FromSeconds(0.5);
        private readonly UpdatesState _updatesState;
        private readonly TelegramClient _client;
        private readonly long? _channelId;
        private readonly ILogger _logger;

        public UpdateProcessor(TelegramClient client, long? channelId, ILogger logger, UpdatesState updatesState)
        {
            _client = client;
            _channelId = channelId;
            _updatesState = updatesState;
            _logger = logger.ForContext<UpdateProcessor>();
        }

        public override async Task LoopAsync(CancellationToken stoppingToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            while (true)
            {
                try
                {
                    if (currentState!.AlreadyHandled)
                    {
                        currentState = StateSignaler.GetCurrentState(true);
                    }

                    if (!currentState!.AlreadyHandled)
                    {
                        var skipTick = false;
                        switch (currentState.Signal)
                        {
                            case ResumableSignalState.Start:
                                SetSignalHandled(ResumableLoopState.Running, currentState);
                                _logger.Information("{Name} started", ToString());
                                skipTick = true;
                                break;
                            case ResumableSignalState.Stop:
                                _logger.Information("{Name} stopped", ToString());
                                SetSignalHandled(ResumableLoopState.Stopped, currentState);
                                return;
                            case ResumableSignalState.Resume:
                                SetSignalHandled(ResumableLoopState.Running, currentState);
                                _logger.Information("{Name} woken up", ToString());
                                break;
                            case ResumableSignalState.Suspend:
                                SetSignalHandled(ResumableLoopState.Suspended, currentState);
                                _logger.Verbose("{Name} suspended", ToString());
                                currentState = await StateSignaler.WaitAsync(stoppingToken);
                                break;
                        }

                        if (skipTick)
                        {
                            continue;
                        }
                    }

                    if (_updatesQueue.GetCount() <= 0)
                    {
                        continue;
                    }


                    var (fetchDifference, toBeApplied) = await ExtractFromQueueAsync(stoppingToken);
                    foreach (var toApply in toBeApplied)
                    {
                        _client.UpdatesDispatcher.DispatchUpdate(toApply);
                    }

                    if (fetchDifference)
                    {
                        await foreach (var updates in InternalDifferenceAsync(stoppingToken))
                        {
                            foreach (var updateBase in updates)
                            {
                                if (_channelId is null && UpdatesTools.IsFromChannel(updateBase, out _))
                                {
                                    _logger.Information("Received channel update after fetching difference in common sequence loop, redirecting update to be processed");
                                    _client.UpdatesReceiver.OnNewUpdates(new UpdateRedirect(updateBase));
                                }
                                else
                                {
                                    _client.UpdatesDispatcher.DispatchUpdate(updateBase);
                                }
                            }
                        }
                    }
                }
                catch (OperationCanceledException e) when (e.CancellationToken == stoppingToken)
                {
                    SetLoopState(ResumableLoopState.Stopped);
                    _logger.Information("Loop stopped from cancellation token");
                    return;
                }
            }
        }

        private async ValueTask<(bool, List<UpdateBase>)> ExtractFromQueueAsync(CancellationToken stoppingToken)
        {
            var toBeApplied = new List<UpdateBase>();
            var fetchDifference = false;
            while (!fetchDifference && _updatesQueue.TryPeek(out var update))
            {
                if(update.Item is UpdateConfig)
                {
                    await _client.ConfigManager.ForceRefreshConfig(stoppingToken);
                }
                if (update.Item is UpdatesTooLong or UpdateChannelTooLong)
                {
                    update.DequeueItem();
                    fetchDifference = true;
                    continue;
                }

                if (update.Item is Channel or ChannelForbidden)
                {
                    if (!UpdatesTools.IsInChat((ChatBase)update.Item))
                    {
                        _client.UpdatesReceiver.CloseProcessor(_channelId!.Value);
                        break;
                    }
                }

                UpdateCheckResult updateCheckResult;
                SearchType? searchType = null;
                int? newPts;
                int? newQts = null;
                if(UpdatesTools.GetApplyOnPts(update.Item, out var at))
                {
                    var (localPts, _, _, _, _) = _updatesState.GetData();
                    if (localPts < at.Value)
                    {
                        _logger.Information("Postponing update {Update} to be applied at pts {Pts}", update.Item, at.Value);
                        _applyAt.Insert(at.Value, (UpdateBase)update.Item);
                    }
                    
                    update.DequeueItem();
                    continue;
                }

                if (UpdatesTools.TryExtractPts(update.Item, out newPts, out var ptsCount))
                {
                    searchType = SearchType.Pts;
                    updateCheckResult = CheckPts(newPts!.Value, ptsCount!.Value);
                }
                else if (UpdatesTools.TryExtractQts(update.Item, out newQts))
                {
                    searchType = SearchType.Qts;
                    updateCheckResult = CheckQts(newQts!.Value);
                }
                else
                {
                    _logger.Verbose("Adding update {Update} to list because it doesn't have PTS nor QTS", update.Item);
                    updateCheckResult = UpdateCheckResult.CanBeApplied;
                }

                switch (updateCheckResult)
                {
                    case UpdateCheckResult.GapDetected:
                        {
                            var findGapFillingUpdate = FindGapFillingUpdate(searchType!.Value, out newQts, out newPts);
                            if(findGapFillingUpdate is null)
                            {
                                _logger.Information(messageTemplate: "Waiting {Time}ms before fetching difference", WaitTime.TotalMilliseconds);
                                await Task.Delay(WaitTime, stoppingToken);
                                findGapFillingUpdate = FindGapFillingUpdate(searchType!.Value, out newQts, out newPts);
                            }

                            if (findGapFillingUpdate is not null)
                            {
                                _logger.Information("Update gap filled after waiting without fetching difference");
                                toBeApplied.Add((UpdateBase)findGapFillingUpdate);
                                if (newPts is not null)
                                {
                                    if (_applyAt.TryRemoveAll(newPts.Value, out var postponedUpdates))
                                    {
                                        foreach (var psUpdate in postponedUpdates)
                                        {
                                            _logger.Information("Applying postponed update {Upd}", psUpdate);
                                            toBeApplied.Add(psUpdate);
                                        }
                                    }
                                }
                                //Not dequeuing update here because FindGapFillingUpdate resetted the current item handle
                                _updatesState.SetData(qts: newQts, pts: newPts);
                            }
                            else
                            {
                                _logger.Information("No update that could fill the gap arrived after waiting, fetching difference...");
                                fetchDifference = true;
                            }

                            break;
                        }
                    case UpdateCheckResult.CanBeApplied:
                        {
                            if (update.Item is UpdateBase updBase)
                            {
                                toBeApplied.Add(updBase);
                            }

                            if(newPts is not null)
                            {
                                if(_applyAt.TryRemoveAll(newPts.Value, out var postponedUpdates))
                                {
                                    foreach(var psUpdate in postponedUpdates)
                                    {
                                        _logger.Information("Applying postponed update {Upd}", psUpdate);
                                        toBeApplied.Add(psUpdate);
                                    }
                                }
                            }

                            update.DequeueItem();
                            _updatesState.SetData(qts: newQts, pts: newPts);
                            break;
                        }
                    case UpdateCheckResult.AlreadyApplied:
                        {
                            update.DequeueItem();
                            break;
                        }
                }
            }

            return (fetchDifference, toBeApplied);
        }

        private async IAsyncEnumerable<List<UpdateBase>> InternalDifferenceAsync([EnumeratorCancellation] CancellationToken token)
        {
            var done = false;
            while (!done)
            {
                var (localPts, localQts, _, localDate, _) = _updatesState.GetData();
                if (_channelId is null)
                {
                    var difference = await _client.Api.CloudChatsApi.Updates.GetDifferenceAsync(localPts, localDate, localQts, cancellationToken: token);
                    if (difference.RpcCallFailed)
                    {
                        _logger.Error("Couldn't get difference because error {Error} occured", difference.Error);
                        yield break;
                    }

                    switch (difference.Response)
                    {
                        case DifferenceEmpty empty:
                            _logger.Information("Received differenceEmpty for common sequence");
                            _updatesState.SetData(date: empty.Date, seq: empty.Seq);
                            yield break;
                        case DifferenceTooLong differenceTooLong:
                            _logger.Information("Received difference too long repeating request with PTS {Pts} for common sequence", differenceTooLong.Pts);
                            _updatesState.SetData(differenceTooLong.Pts);
                            continue;
                        case DifferenceSlice or Difference:
                            {
                                DifferenceTools.GetDifferenceChanges(difference.Response, out var newMessages, out var newEncryptedMessages, out var newUpdates, out var chats, out var users, out var state);
                                _logger.Information("Received difference, new messages: {MCount}, new encrypted messages: {MECount}, other updates: {OCount}, chats: {CCount}, users: {UCount}", newMessages.Count, newEncryptedMessages.Count, newUpdates.Count, chats.Count, users.Count);
                                _updatesState.SetData(state.Pts, state.Qts, state.Seq, state.Date);
                                yield return newMessages.Select(UpdatesTools.FromMessageToUpdate).Concat(newUpdates).ToList();
                                done = difference.Response is Difference;
                                break;
                            }
                    }
                }
                else
                {
                    var difference = await _client.Api.CloudChatsApi.Updates.GetChannelDifferenceAsync(_channelId.Value, new ChannelMessagesFilterEmpty(), localPts, 100, true, cancellationToken: token);
                    if (difference.RpcCallFailed)
                    {
                        _logger.Error("Couldn't get difference because error {Error} occured for channel {Channel}, removing channel from states", difference.Error, _channelId.Value);
                        yield break;
                    }

                    switch (difference.Response)
                    {
                        case ChannelDifferenceEmpty empty:
                            _logger.Information("Received differenceEmpty for channel {ChannelId}", _channelId.Value);
                            _updatesState.SetData(pts: empty.Pts);
                            yield break;
                        case ChannelDifferenceTooLong differenceTooLong:
                            //TODO: Implement this
                            _logger.Information("Received difference too long, not yet implemented. Setting new PTS for {ChannelId}", _channelId.Value);
                            _updatesState.SetData(((Dialog)differenceTooLong.Dialog).Pts);
                            continue;
                        case ChannelDifference channelDifference:
                            {
                                _logger.Information("Received difference for channel {ChannelId}, new messages: {MCount}, other updates: {OCount}, chats: {CCount}, users: {UCount}", _channelId.Value, channelDifference.NewMessages.Count, channelDifference.OtherUpdates.Count, channelDifference.Chats.Count, channelDifference.Users.Count);
                                _updatesState.SetData(channelDifference.Pts);
                                yield return channelDifference.NewMessages.Select(UpdatesTools.FromMessageToUpdate).Concat(channelDifference.OtherUpdates).ToList();
                                done = channelDifference.Final;
                                break;
                            }
                    }
                }
            }
        }


        private IObject? FindGapFillingUpdate(SearchType searchType, out int? newQts, out int? newPts)
        {
            newPts = null;
            newQts = null;
            foreach (var queuedItemHandle in _updatesQueue)
            {
                if (queuedItemHandle.Item is not UpdateBase update)
                {
                    continue;
                }

                var found = searchType switch
                {
                    SearchType.Pts => UpdatesTools.TryExtractPts(update, out newPts, out var ptsCount) && CheckPts(newPts!.Value, ptsCount!.Value) is UpdateCheckResult.CanBeApplied,
                    SearchType.Qts => UpdatesTools.TryExtractQts(update, out newQts) && CheckQts(newQts!.Value) is UpdateCheckResult.CanBeApplied,
                    _ => false
                };

                if (found)
                {
                    queuedItemHandle.DequeueItem();
                    return queuedItemHandle.Item;
                }
            }

            return null;
        }

        public void AddUpdateToQueue(IObject update)
        {
            if (update is not UpdateBase && update is not UpdatesBase && update is not ChatBase)
            {
                _logger.Warning("Received invalid update of type {Type}", update);
                return;
            }

            _updatesQueue.Enqueue(update);
        }

        private UpdateCheckResult CheckPts(int pts, int ptsCount)
        {
            var (localPts, _, _, _, _) = _updatesState.GetData();
            if (localPts + ptsCount == pts)
            {
                _logger.Information("PTS match: Local pts {Local} + pts count {Count} equals received pts {Received}", localPts, ptsCount, pts);
                return UpdateCheckResult.CanBeApplied;
            }

            if (localPts + ptsCount > pts)
            {
                _logger.Information("Update already applied: Local pts {Local} + pts count {Count} is bigger than received pts {Received}", localPts, ptsCount, pts);
                return UpdateCheckResult.AlreadyApplied;
            }

            if (localPts + ptsCount < pts)
            {
                _logger.Information("Update gap detected: Local pts {Local} + pts count {Count} is smaller than received pts {Received})", localPts, ptsCount, pts);
                return UpdateCheckResult.GapDetected;
            }

            //unreachable
            throw new InvalidOperationException();
        }

        private UpdateCheckResult CheckQts(int qts)
        {
            var (_, localQts, _, _, _) = _updatesState.GetData();
            if (localQts + 1 == qts)
            {
                _logger.Information("QTS match ({Local} + {Count} == {Received})", localQts, 1, qts);
                return UpdateCheckResult.CanBeApplied;
            }

            if (localQts + 1 > qts)
            {
                _logger.Information("Update already applied: QTS({Local} + {Count} > {Received})", localQts, 1, qts);
                return UpdateCheckResult.AlreadyApplied;
            }

            if (localQts + 1 < qts)
            {
                _logger.Information("Update gap detected: QTS({Local} + {Count} < {Received})", localQts, 1, qts);
                return UpdateCheckResult.GapDetected;
            }

            //unreachable
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return _channelId is null ? "Common sequence update processor" : $"Update processor for channelId {_channelId}";
        }
    }
}