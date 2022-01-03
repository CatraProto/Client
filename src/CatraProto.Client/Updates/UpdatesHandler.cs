using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.Client.Updates.Interfaces;
using Serilog;

namespace CatraProto.Client.Updates
{
    class UpdatesHandler
    {
        private readonly AsyncLock _asyncLock = new AsyncLock();
        private readonly UpdatesState _commonSequence;
        private readonly IEventHandler _eventHandler;
        private readonly ClientSession _clientSession;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        public UpdatesHandler(IEventHandler eventHandler, ClientSession clientSession, TelegramClient client, ILogger logger)
        {
            _eventHandler = eventHandler;
            _clientSession = clientSession;
            _client = client;
            _logger = logger.ForContext<UpdatesHandler>();
            _commonSequence = _clientSession.SessionManager.SessionData.UpdatesStates.GetState(null);
        }


        private void PropagateUpdate(UpdateBase updateBase)
        {
            Task.Run(() => _eventHandler.OnUpdate(updateBase));
        }
        
        public async Task ApplyUpdateAsync(UpdateBase updateBase, bool skipGapCheck)
        {
            if (skipGapCheck)
            {
                //apply
                return;
            }
            
            var (localPts, localQts, _, _) = _commonSequence.GetData();
            if (UpdatesTools.GetPts(updateBase, out var pts, out var ptsCount))
            {
                if (localPts + ptsCount == pts)
                {
                    _logger.Information("PTS match ({Local} + {Count} == {Received}), propagating update", localPts, ptsCount, pts);
                    _commonSequence.SetData(pts: pts);
                    PropagateUpdate(updateBase);
                    return;
                }
                
                if (localPts + ptsCount > pts)
                {
                    _logger.Information("Update already applied: PTS({Local} + {Count} > {Received}), skipping update", localPts, ptsCount, pts);
                    return;
                }
                
                                
                if (localPts + ptsCount < pts)
                {
                    _logger.Information("Update gap detected: PTS({Local} + {Count} < {Received}), fetching difference", localPts, ptsCount, pts);
                    await FetchDifferenceAsync();
                    return;
                }
            }
            
            if (UpdatesTools.GetQts(updateBase, out var qts))
            {
                if (localQts + 1 == qts)
                {
                    _logger.Information("QTS match ({Local} + {Count} == {Received}), propagating update and saving state", localQts, 1, qts);
                    _commonSequence.SetData(qts: qts);
                    PropagateUpdate(updateBase);
                    return;
                }
                
                if (localQts + 1 > qts)
                {
                    _logger.Information("Update already applied: QTS({Local} + {Count} > {Received}), skipping update", localQts, 1, qts);
                    return;
                }

                if (localQts + 1 < qts)
                {
                    _logger.Information("Update gap detected: QTS({Local} + {Count} < {Received}), fetching difference", localQts, 1, qts);
                    await FetchDifferenceAsync();
                    return;
                }
            }
            
            _logger.Warning("Couldn't find qts nor pts for update {Update}", updateBase);
        }
        
        public async Task FetchDifferenceAsync()
        {
            bool done = false;
            while (!done)
            {
                var (localPts, localQts, _, localDate) = _commonSequence.GetData();
                var difference = await _client.Api.CloudChatsApi.Updates.GetDifferenceAsync(localPts, localDate, localQts);
                if (difference.RpcCallFailed)
                {
                    _logger.Error("Couldn't get difference because error {Error} occured", difference.Error);
                    return;
                }

                if (difference.Response is DifferenceEmpty)
                {
                    _logger.Information("Received differenceEmpty from server");
                    return;
                }

                if (difference.Response is DifferenceTooLong differenceTooLong)
                {
                    _logger.Information("Received difference too long repeating request with PTS {Pts}", differenceTooLong.Pts);
                    _commonSequence.SetData(differenceTooLong.Pts);
                    continue;
                }

                if (difference.Response is DifferenceSlice or Difference)
                {
                    UpdatesTools.GetDifferenceChanges(difference.Response, out var newMessages, out var newEncryptedMessages, out var newUpdates, out var chats, out var users, out var state);
                    foreach (var chat in chats)
                    {
                        _logger.Information("Received chat update {Chat}", chat.ToJson());
                    }
                    
                    foreach (var user in users)
                    {
                        _logger.Information("Received user update {User}", user.ToJson());
                    }
                    
                    _commonSequence.SetData(state.Pts, state.Qts, state.Seq, state.Date);
                    done = difference.Response is Difference;
                }
            }
        }

        public async void OnNewUpdates(UpdatesBase updatesBase)
        {
            _logger.Information("Received new update {Update}", updatesBase);
            using (await _asyncLock.LockAsync())
            {
                var (localPts, localQts, localSeq, localDate) = _commonSequence.GetData();
                if (UpdatesTools.GetSeq(updatesBase, out var finalSeq, out var seqStart, out var date))
                {
                    if (seqStart == 0 || localSeq + 1 == seqStart)
                    {
                        _logger.Information("Received update can be applied SEQ({LocalSeq} + 1 == {SeqStart}) or seqStart == 0", localSeq, seqStart);
                        if (UpdatesTools.GetUpdatesData(updatesBase, out var chats, out var users, out var updates))
                        {
                            //TODO: Db for chats and users
                            foreach (var update in updates)
                            {
                                await ApplyUpdateAsync(update, false);
                            }
                        }
                        _commonSequence.SetData(seq: finalSeq, date: date);
                        
                        return;
                    }

                    if (localSeq + 1 > seqStart)
                    {
                        _logger.Information("Received update was already applied SEQ({LocalSeq} + 1 > {SeqStart})", localSeq, seqStart);
                        return;
                    }

                    if (localSeq + 1 < seqStart)
                    {
                        _logger.Information("Seq gap detected SEQ({LocalSeq} + 1 < {SeqStart}), fetching difference...", localSeq, seqStart);
                        await FetchDifferenceAsync();
                    }
                }
            }
        }
        
        public async Task FetchLostUpdatesAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                await FetchDifferenceAsync();
            }
        }
    }
}