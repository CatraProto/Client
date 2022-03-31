using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Collections;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.Tools;
using CatraProto.Client.Updates.CustomTypes;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Updates
{
    class UpdatesReceiver
    {
        private readonly Dictionary<long, (ResumableLoopController Controller, UpdateProcessor Processor)> _processors = new Dictionary<long, (ResumableLoopController, UpdateProcessor)>();
        private readonly (ResumableLoopController Controller, UpdateProcessor Processor) _commonLoop;
        private readonly object _mutex = new object();
        private readonly UpdatesState _commonSequence;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        public UpdatesReceiver(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<UpdatesReceiver>();
            _commonSequence = client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState();
            _commonLoop.Processor = new UpdateProcessor(client, null, logger, _commonSequence);
            _commonLoop.Controller = new ResumableLoopController(_logger);
        }

        public void FillProcessors()
        {
            lock (_mutex)
            {
                _commonLoop.Controller.BindTo(_commonLoop.Processor);
                _commonLoop.Controller.SendSignal(ResumableSignalState.Start, out _);
                _commonLoop.Controller.SendSignal(ResumableSignalState.Suspend, out _);
                foreach (var (chatId, state) in _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetAllChannelsStates())
                {
                    if (!state.GetData().isActive)
                    {
                        continue;
                    }

                    _logger.Information("Creating processor for chatId {ChatId}", chatId);
                    var tuple = CreateProcessor(chatId);
                    _processors.TryAdd(chatId, tuple);
                }
            }
        }

        public void OnNewUpdates(IObject socketObject, IMethod? callingMethod = null)
        {
            var channelUpdates = new MultiValueDictionary<long, IObject>();
            var commonUpdates = new List<IObject>();
            var localSeq = _commonSequence.GetData().seq;
            IObject? update = null;

            _logger.Information("Received new update {Update}", socketObject);
            if (socketObject is UpdatesBase updatesBase)
            {
                if (UpdatesTools.GetSeq(updatesBase, out var finalSeq, out var seqStart, out var date))
                {
                    if (seqStart == 0 || localSeq + 1 == seqStart)
                    {
                        if (UpdatesTools.GetUpdatesData(updatesBase, out var updates))
                        {
                            foreach (var updateObj in updates)
                            {
                                if (UpdatesTools.IsFromChannel(updateObj, out var channelId))
                                {
                                    channelUpdates.Insert(channelId!.Value, updateObj);
                                }
                                else
                                {
                                    commonUpdates.Add(updateObj);
                                }
                            }

                            if(finalSeq > 0 && date > 0)
                            {
                                _commonSequence.SetData(seq: finalSeq, date: date);
                            }
                        }
                    }
                    else if (localSeq + 1 > seqStart)
                    {
                        _logger.Information("Received update was already applied SEQ({LocalSeq} + 1 > {SeqStart})", localSeq, seqStart);
                        return;
                    }
                    else if (localSeq + 1 < seqStart)
                    {
                        _logger.Information("Seq gap detected SEQ({LocalSeq} + 1 < {SeqStart}), Manually sending updates too long to fetch difference...", localSeq, seqStart);
                        commonUpdates.Add(new UpdatesTooLong());
                    }
                }
                else
                {
                    switch (socketObject)
                    {
                        case UpdateRedirect updateRedirect:
                            update = updateRedirect.Update;
                            break;
                        case UpdatesTooLong:
                            update = socketObject;
                            break;
                        case UpdateShort updateShort:
                            update = updateShort.Update;
                            _commonSequence.SetData(date: updateShort.Date);
                            break;
                        case UpdateShortChatMessage updateShortChatMessage:
                            update = UpdatesTools.ConvertUpdate(updateShortChatMessage);
                            break;
                        case UpdateShortMessage updateShortMessage:
                            update = UpdatesTools.ConvertUpdate(updateShortMessage);
                            break;
                        case UpdateShortSentMessage updateShortSentMessage:
                            if (callingMethod != null)
                            {
                                var peer = PeerTools.ExtractPeerFromMethod(callingMethod);
                                if (peer is PeerChannel channel)
                                {
                                    channelUpdates.Insert(channel.ChannelId, UpdatesTools.ConvertUpdate(updateShortSentMessage, callingMethod));
                                }
                                else
                                {
                                    commonUpdates.Add(UpdatesTools.ConvertUpdate(updateShortSentMessage, callingMethod));
                                }
                            }

                            break;
                        default:
                            return;
                    }
                }
            }
            else
            {
                update = socketObject;
            }

            if (update is not null)
            {
                if (UpdatesTools.IsFromChannel(update, out var channelId))
                {
                    channelUpdates.Insert(channelId!.Value, update);
                }
                else
                {
                    commonUpdates.Add(update);
                }
            }

            if (commonUpdates.Count > 0)
            {
                foreach (var commonUpdate in commonUpdates)
                {
                    _commonLoop.Processor.AddUpdateToQueue(commonUpdate);
                }

                _commonLoop.Controller.ResumeAndSuspendAsync();
            }

            lock (_mutex)
            {
                if (channelUpdates.Count > 0)
                {
                    foreach (var channelUpdate in channelUpdates)
                    {
                        var getProcessor = GetProcessor(channelUpdate.Key);
                        if (getProcessor != null)
                        {
                            var (controller, processor) = getProcessor.Value;
                            foreach (var upd in channelUpdate.Value)
                            {
                                processor.AddUpdateToQueue(upd);
                            }

                            controller.ResumeAndSuspendAsync();
                        }
                        else
                        {
                            _logger.Information("Won't process updates for channel {Channel} because processor does not exist", channelUpdate.Key);
                        }
                    }
                }
            }
        }
        

        public (ResumableLoopController Controller, UpdateProcessor Processor)? GetProcessor(long channelId)
        {
            lock (_mutex)
            {
                if (_processors.TryGetValue(channelId, out var tuple))
                {
                    return tuple;
                }
                else
                {
                    return null;
                }
            }
        }

        public (ResumableLoopController Controller, UpdateProcessor Processor) CreateProcessor(long channelId, bool forceFetchOnCreate = false)
        {
            lock (_mutex)
            {
                if (!_processors.TryGetValue(channelId, out var tuple))
                {
                    _logger.Information("Creating processor for channel {Id}", channelId);
                    var state = _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState(channelId);
                    tuple.Processor = new UpdateProcessor(_client, channelId, _logger, state);
                    tuple.Controller = new ResumableLoopController(_logger);
                    tuple.Controller.BindTo(tuple.Processor);
                    state.SetData(isActive: true);

                    if (forceFetchOnCreate)
                    {
                        _logger.Information("Forcing get difference on channel {Id}", channelId);
                        tuple.Processor.AddUpdateToQueue(new UpdateChannelTooLong());
                    }

                    tuple.Controller.SendSignal(ResumableSignalState.Start, out _);
                    tuple.Controller.SendSignal(ResumableSignalState.Suspend, out _);
                    _processors.TryAdd(channelId, tuple);
                }

                return tuple;
            }
        }

        public void CloseProcessor(long channelId)
        {
            lock (_mutex)
            {
                if (_processors.Remove(channelId, out var tuple))
                {
                    _logger.Information("Closing processor for channel {Id}", channelId);
                    tuple.Controller.SendSignal(ResumableSignalState.Stop, out _);
                    _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState(channelId).SetData(isActive: false);
                }
            }
        }

        public Task ForceGetDifferenceAllAsync(bool waitCompletion)
        {
            Task waitTask;
            lock (_mutex)
            {
                if (!_client.ClientSession.SessionManager.SessionData.Authorization.IsAuthorized(out _, out _, out _))
                {
                    _logger.Information("Skipping get difference all because we are not authorized");
                    return Task.CompletedTask;
                }

                _logger.Information("Forcefully fetching difference in all states by sending UpdatesTooLong");
                _commonLoop.Processor.AddUpdateToQueue(new UpdatesTooLong());
                var commonTask = _commonLoop.Controller.ResumeAndSuspendAsync();

                var tasksToWait = new Task[_processors.Count + 1];

                var i = 0;
                foreach (var (chatId, (controller, processor)) in _processors)
                {
                    _logger.Information("Sending updateChannelTooLong to processor {Id} to fetch updates", chatId);
                    processor.AddUpdateToQueue(new UpdateChannelTooLong());
                    tasksToWait[i++] = controller.ResumeAndSuspendAsync();
                }

                tasksToWait[_processors.Count] = commonTask;

                waitTask = waitCompletion ? Task.WhenAll(tasksToWait) : Task.CompletedTask;
            }

            return waitTask;
        }

        public Task CloseAllAsync()
        {
            lock (_mutex)
            {
                _logger.Information("Stopping all updates processors");
                var size = _processors.Count;
                var tasksToWait = new Task[size + 1];

                var i = 0;
                foreach (var (chatId, (controller, processor)) in _processors)
                {
                    _logger.Information("Stopping update processor for channel {ChatId}", chatId);
                    tasksToWait[i++] = controller.TrySignalAsync(ResumableSignalState.Stop);
                }

                tasksToWait[size] = _commonLoop.Controller.TrySignalAsync(ResumableSignalState.Stop);
                return Task.WhenAll(tasksToWait);
            }
        }
    }
}