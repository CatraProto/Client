/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.Client.Updates.CustomTypes;
using CatraProto.Client.Updates.Enums;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Updates
{
    internal class UpdateProcessor : LoopImplementation<ResumableLoopState, ResumableSignalState>
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
            if (channelId is not null)
            {
                _logger = _logger.ForContext("UpdateProcessorId", channelId.Value);
            }
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
                                _logger.Information("Loop started");
                                skipTick = true;
                                break;
                            case ResumableSignalState.Stop:
                                _logger.Information("Loop stopped");
                                SetSignalHandled(ResumableLoopState.Stopped, currentState);
                                return;
                            case ResumableSignalState.Resume:
                                SetSignalHandled(ResumableLoopState.Running, currentState);
                                _logger.Information("Loop woken up");
                                break;
                            case ResumableSignalState.Suspend:
                                SetSignalHandled(ResumableLoopState.Suspended, currentState);
                                _logger.Verbose("Loop suspended");
                                currentState = await StateSignaler.WaitAsync(stoppingToken);
                                break;
                        }

                        if (skipTick)
                        {
                            continue;
                        }
                    }

                    if (_updatesQueue.GetCount() == 0)
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
            while (_updatesQueue.TryPeek(out var update))
            {
                _logger.Information("Extracted {Update} from queue, remaining items: {Remaining}", update.Item, _updatesQueue.GetCount());
                if (update.Item is UpdateConfig)
                {
                    _logger.Information("Received UpdateConfig, refetching configuration");
                    _ = Task.Run(async () => 
                    {
                        try
                        {
                            await _client.ConfigManager.ForceRefreshConfig(stoppingToken);
                        }
                        catch (Exception e)
                        {
                            _logger.Error(e, "Exception occurred while forcefully refetching configuration");
                        }
                    }, stoppingToken);
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
                        _logger.Information("Closing processor because we are not participants of this chat");
                        _client.UpdatesReceiver.CloseProcessor(_channelId!.Value);
                        break;
                    }
                }

                UpdateCheckResult updateCheckResult;
                SearchType? searchType = null;
                int? newQts = null;
                if (UpdatesTools.GetApplyOnPts(update.Item, out var at))
                {
                    var (localPts, _, _, _, _) = _updatesState.GetData();
                    if (localPts < at!.Value)
                    {
                        _logger.Information("Postponing update {Update} to be applied at pts {Pts}", update.Item, at.Value);
                        _applyAt.Insert(at.Value, (UpdateBase)update.Item);
                    }

                    update.DequeueItem();
                    continue;
                }

                // Null check is necessary because some updates may have int? as pts, ptsCount or qts
                if (UpdatesTools.TryExtractPts(update.Item, out var newPts, out var ptsCount))
                {
                    if(newPts is null || ptsCount is null)
                    {
                        _logger.Information("Skipping sequence checks for {Update} because its pts or pts count are null", update.Item);
                        updateCheckResult = UpdateCheckResult.CanBeApplied;
                    }
                    else
                    {
                        searchType = SearchType.Pts;
                        updateCheckResult = CheckPts(newPts!.Value, ptsCount!.Value);
                    }
                }
                else if (UpdatesTools.TryExtractQts(update.Item, out newQts))
                {
                    if (newPts is null || ptsCount is null)
                    {
                        _logger.Information("Skipping sequence checks for {Update} because its qts is null", update.Item);
                        updateCheckResult = UpdateCheckResult.CanBeApplied;
                    }
                    else
                    {
                        searchType = SearchType.Qts;
                        updateCheckResult = CheckQts(newQts!.Value);
                    }
                }
                else
                {
                    _logger.Verbose("Adding update {Update} to list because it doesn't have PTS nor QTS", update.Item);
                    updateCheckResult = UpdateCheckResult.CanBeApplied;
                }

                if ((newPts is not null || newQts is not null) && fetchDifference)
                {
                    _logger.Information("Skipping update because it contains pts/qts but difference was requested");
                    update.DequeueItem();
                    continue;
                }

                switch (updateCheckResult)
                {
                    case UpdateCheckResult.GapDetected:
                        {
                            var findGapFillingUpdate = FindGapFillingUpdate(searchType!.Value, out newQts, out newPts);
                            if (findGapFillingUpdate is null)
                            {
                                _logger.Information(messageTemplate: "Waiting {Time}ms before fetching difference", WaitTime.TotalMilliseconds);
                                await Task.Delay(WaitTime, stoppingToken);
                                findGapFillingUpdate = FindGapFillingUpdate(searchType!.Value, out newQts, out newPts);
                            }

                            if (findGapFillingUpdate is not null)
                            {
                                _logger.Information("Update gap filled after waiting without fetching difference");
                                if (!ApplyUpdate((UpdateBase)findGapFillingUpdate, newPts, toBeApplied))
                                {
                                    fetchDifference = true;
                                    break;
                                }
                                //Not dequeuing update here because FindGapFillingUpdate resetted the current item handle
                                _updatesState.SetData(qts: newQts, pts: newPts);
                            }
                            else
                            {
                                _logger.Information("No update that could fill the gap arrived even after waiting, fetching difference");
                                fetchDifference = true;
                            }

                            break;
                        }
                    case UpdateCheckResult.CanBeApplied:
                        {
                            if (update.Item is UpdateBase updBase)
                            {
                                if (!ApplyUpdate(updBase, newPts, toBeApplied))
                                {
                                    fetchDifference = true;
                                    break;
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
                        var waitTime = TimeSpan.FromSeconds(5);
                        if(difference.Error is FloodWaitError error)
                        {
                            waitTime = error.WaitTime;
                        }

                        _logger.Error("Couldn't get difference because error {Error} occured, retrying in {Seconds} seconds", waitTime.TotalSeconds, difference.Error);
                        await Task.Delay(waitTime, token);
                        continue;
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
                        var waitTime = TimeSpan.FromSeconds(5);
                        if (difference.Error is FloodWaitError error)
                        {
                            waitTime = error.WaitTime;
                        }

                        _logger.Error("Couldn't get difference because error {Error} occured, retrying in {Seconds} seconds", waitTime.TotalSeconds, difference.Error);
                        await Task.Delay(waitTime, token);
                        continue;
                    }

                    switch (difference.Response)
                    {
                        case ChannelDifferenceEmpty empty:
                            _logger.Information("Received differenceEmpty");
                            _updatesState.SetData(pts: empty.Pts);
                            yield break;
                        case ChannelDifferenceTooLong differenceTooLong:
                            //TODO: Implement this
                            _logger.Information("Received difference too long, not yet implemented. Setting new PTS to {Pts}", ((Dialog)differenceTooLong.Dialog).Pts);
                            _updatesState.SetData(((Dialog)differenceTooLong.Dialog).Pts);
                            continue;
                        case ChannelDifference channelDifference:
                            {
                                _logger.Information("Received difference. new messages: {MCount}, other updates: {OCount}, chats: {CCount}, users: {UCount}", channelDifference.NewMessages.Count, channelDifference.OtherUpdates.Count, channelDifference.Chats.Count, channelDifference.Users.Count);
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
                    // Null check is necessary because some updates may have int? as pts, ptsCount or qts
                    SearchType.Pts => UpdatesTools.TryExtractPts(update, out newPts, out var ptsCount) && newPts is not null && ptsCount is not null && CheckPts(newPts!.Value, ptsCount!.Value) is UpdateCheckResult.CanBeApplied,
                    SearchType.Qts => UpdatesTools.TryExtractQts(update, out newQts) && newQts is not null && CheckQts(newQts!.Value) is UpdateCheckResult.CanBeApplied,
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

        private bool MustFetchDifference(UpdateBase update)
        {
            switch (update)
            {
                case UpdateNewMessage message:
                    return MustFetchDifference(message.Message);
                case UpdateNewChannelMessage message:
                    return MustFetchDifference(message.Message);
                case UpdateNewScheduledMessage message:
                    return MustFetchDifference(message.Message);
                case UpdateEditChannelMessage updateEdit:
                    return MustFetchDifference(updateEdit.Message);
                case UpdateEditMessage updateEdit:
                    return MustFetchDifference(updateEdit.Message);
                case UpdateDraftMessage draft:
                    var draftPeer = PeerId.FromPeer(draft.Peer);
                    if (!_client.DatabaseManager.PeerDatabase.HavePeer(draftPeer))
                    {
                        _logger.Information("Must fetch difference because we're missing data about peer {Peer} in update_draft", draftPeer);
                        return true;
                    }

                    if (draft.Draft is DraftMessage draftMessage && draftMessage.Entities is not null && MustFetchDifference(draftMessage.Entities))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private bool MustFetchDifference(MessageBase messageBase)
        {
            PeerBase? replyTo = null;
            PeerBase? fromId = null;
            PeerBase? peerId = null;

            switch (messageBase)
            {
                case Message message:
                    peerId = message.PeerId;
                    fromId = message.FromId;
                    replyTo = message.ReplyTo?.ReplyToPeerId;
                    if (message.FwdFrom is not null)
                    {
                        if (message.FwdFrom.SavedFromPeer is not null)
                        {
                            var savedFromPeer = PeerId.FromPeer(message.FwdFrom.SavedFromPeer);
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(savedFromPeer))
                            {
                                _logger.Information("Must fetch difference because we're missing data about saved_from_peer {Peer} in fwd_from", savedFromPeer);
                                return true;
                            }
                        }

                        if (message.FwdFrom.FromId is not null)
                        {
                            var fwdFromId = PeerId.FromPeer(message.FwdFrom.FromId);
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(fwdFromId))
                            {
                                _logger.Information("Must fetch difference because we're missing data about from_id {FromId} in fwd_from", fromId);
                                return true;
                            }
                        }
                    }

                    if (message.Entities is not null && MustFetchDifference(message.Entities))
                    {
                        return true;
                    }

                    if (message.Media is not null && message.Media is MessageMediaContact contact && !_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(contact.UserId)))
                    {
                        _logger.Information("Must fetch difference because we're missing data about user {UserId} in message_media_contact", contact.UserId);
                        return true;
                    }

                    if (message.ViaBotId is not null && !_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(message.ViaBotId.Value)))
                    {
                        _logger.Information("Must fetch difference because we're missing data about bot {Id} in via_bot", message.ViaBotId.Value);
                        return true;
                    }
                    break;
                case MessageService messageService:
                    peerId = messageService.PeerId;
                    fromId = messageService.FromId;
                    replyTo = messageService.ReplyTo?.ReplyToPeerId;
                    List<long>? userIds = null;
                    switch (messageService.Action)
                    {
                        case MessageActionGeoProximityReached proximityReached:
                            var proxPeer = PeerId.FromPeer(proximityReached.FromId);
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(proxPeer))
                            {
                                _logger.Information("Must fetch difference because we're missing data about from_id peer {Peer} in geo proximity", proxPeer);
                                return true;
                            }

                            var proxToId = PeerId.FromPeer(proximityReached.ToId);
                            if (_client.DatabaseManager.PeerDatabase.HavePeer(proxToId))
                            {
                                _logger.Information("Must fetch difference because we're missing data about to_id peer {Peer} in geo proximity", proxPeer);
                                return true;
                            }
                            break;
                        case MessageActionChannelMigrateFrom migrateFrom:
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsGroup(migrateFrom.ChatId)))
                            {
                                _logger.Information("Must fetch difference because we're missing data about chat {ChatId} in migrate_from", migrateFrom.ChatId);
                                return true;
                            }
                            break;
                        case MessageActionChatMigrateTo migrate:
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsChannel(migrate.ChannelId)))
                            {
                                _logger.Information("Must fetch difference because we're missing data about channel {ChannelId} in migrate_to", migrate.ChannelId);
                                return true;
                            }
                            break;
                        case MessageActionChatJoinedByLink joinedByLink:
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(joinedByLink.InviterId)))
                            {
                                _logger.Information("Must fetch difference because we're missing data about inviter {InviterId} in joined_by_link", joinedByLink.InviterId);
                                return true;
                            }
                            break;
                        case MessageActionChatDeleteUser deleteUser:
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(deleteUser.UserId)))
                            {
                                _logger.Information("Must fetch difference because we're missing data about user {UserId} in joined_by_link", deleteUser.UserId);
                                return true;
                            }
                            break;
                        case MessageActionChatAddUser addUser:
                            userIds = addUser.Users;
                            break;
                        case MessageActionChatCreate chatCreate:
                            userIds = chatCreate.Users;
                            break;
                        case MessageActionInviteToGroupCall invite:
                            userIds = invite.Users;
                            break;
                    }

                    if (userIds is not null)
                    {
                        foreach (var user in userIds)
                        {
                            if (!_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(user)))
                            {
                                _logger.Information("Must fetch difference because we're missing data about user {UserId}", user);
                                return true;
                            }
                        }
                    }
                    break;
            }

            if (peerId is not null)
            {
                var peerPeerId = PeerId.FromPeer(peerId);
                if (!_client.DatabaseManager.PeerDatabase.HavePeer(peerPeerId))
                {
                    _logger.Information("Must fetch difference because we're missing data about peer {Peer}", peerPeerId);
                    return true;
                }
            }

            if (fromId is not null)
            {
                var fromPeerId = PeerId.FromPeer(fromId);
                if (!_client.DatabaseManager.PeerDatabase.HavePeer(fromPeerId))
                {
                    _logger.Information("Must fetch difference because we're missing data about from_peer {Peer}", fromPeerId);
                    return true;
                }
            }

            if (replyTo is not null)
            {
                var replyPeerId = PeerId.FromPeer(replyTo);
                if (!_client.DatabaseManager.PeerDatabase.HavePeer(replyPeerId))
                {
                    _logger.Information("Must fetch difference because we're missing data about reply_to {Peer}", replyPeerId);
                    return true;
                }
            }

            return false;
        }

        private bool MustFetchDifference(List<MessageEntityBase> entities)
        {
            foreach (var entity in entities)
            {
                if (entity is MessageEntityMentionName entityMentionName && !_client.DatabaseManager.PeerDatabase.HavePeer(PeerId.AsUser(entityMentionName.UserId)))
                {
                    _logger.Information("Must fetch difference because we're missing data about mentioned user {UserId} in entity in FwdFrom", entityMentionName.UserId);
                    return true;
                }
            }

            return false;
        }

        private bool ApplyUpdate(UpdateBase update, int? pts, in List<UpdateBase> updates)
        {
            if (MustFetchDifference(update))
            {
                return false;
            }

            updates.Add(update);
            if (pts is not null)
            {
                if (_applyAt.TryRemoveAll(pts.Value, out var postponedUpdates))
                {
                    foreach (var psUpdate in postponedUpdates)
                    {
                        _logger.Information("Applying postponed update {Upd}", psUpdate);
                        if (MustFetchDifference(update))
                        {
                            return false;
                        }
                        updates.Add(psUpdate);
                    }
                }
            }

            return true;
        }

        public bool AddUpdateToQueue(IObject update)
        {
            if (update is not UpdateBase && update is not UpdatesBase && update is not ChatBase)
            {
                _logger.Warning("Received invalid update of type {Type}", update);
                return false;
            }
            var add = _updatesQueue.Enqueue(update);
            if (add - 1 == 0)
            {
                _logger.Verbose("Added update {Update} to queue, current count: {Count}", update, add);
                return true;
            }
            else
            {
                _logger.Verbose("Not waking up loop because a signal is still being processed, current amount of items {Count}", add);
            }
            return false;
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
                _logger.Information("Update gap detected: Local pts {Local} + pts count {Count} is smaller than received pts {Received}", localPts, ptsCount, pts);
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
            return "UpdateProcessor";
        }
    }
}