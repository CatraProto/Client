using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;

namespace CatraProto.Client.Updates
{
    class UpdatesDispatcher
    {
        private readonly Dictionary<PeerId, Queue<UpdateBase>> _updates = new Dictionary<PeerId, Queue<UpdateBase>>();
        private readonly Queue<UpdateBase> _commonUpdates = new Queue<UpdateBase>();
        private readonly object _mutex = new object();
        private readonly TelegramClient _client;
        private bool _executingCommon = false;
        private readonly ILogger _logger;

        public UpdatesDispatcher(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<UpdatesDispatcher>();
        }

        public void DispatchUpdate(UpdateBase update)
        {
            lock (_mutex)
            {
                var mustInvoke = false;
                Queue<UpdateBase> updatesQueue;
                if (UpdatesTools.TryExtractPeerId(update, out var peerId))
                {
                    if (_updates.TryGetValue(peerId!.Value, out var updatesOutQueue))
                    {
                        updatesQueue = updatesOutQueue;
                    }
                    else
                    {
                        mustInvoke = true;
                        updatesQueue = new Queue<UpdateBase>();
                        _updates.Add(peerId.Value, updatesQueue);
                    }
                }
                else
                {
                    updatesQueue = _commonUpdates;
                    mustInvoke = !_executingCommon;
                }

                updatesQueue.Enqueue(update);
                if (mustInvoke)
                {
                    InvokeCallback(peerId);
                }
            }
        }

        private void OnDispatchingDone(PeerId? peerId)
        {
            lock (_mutex)
            {
                if (peerId is not null)
                {
                    InvokeCallback(peerId);    
                }
                else
                {
                    if (_commonUpdates.Count > 0)
                    {
                        InvokeCallback(null);
                    }
                    else
                    {
                        _executingCommon = false;
                    }
                }
            }
        }

        private void InvokeCallback(PeerId? peerId)
        {
            lock (_mutex)
            {
                UpdateBase? update = null;
                if (peerId is not null)
                {
                    if (_updates.TryGetValue(peerId.Value, out var queue))
                    {
                        if (queue.Count == 0)
                        {
                            _updates.Remove(peerId.Value);
                        }
                        else
                        {
                            update = queue.Dequeue();
                        }
                    }
                }
                else
                {
                    _executingCommon = true;
                    update = _commonUpdates.Dequeue();
                }

                if (update is not null)
                {
                    Task.Run(() => SafelyInvoke(update, peerId));
                }
            }
        }

        private async Task SafelyInvoke(UpdateBase update, PeerId? peerId)
        {
            try
            {
                var ev = _client.EventHandler;
                if (ev is not null)
                {
                    await ev.OnUpdateAsync(update);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "Exception thrown inside user-provided callback");
            }
            finally
            {
                OnDispatchingDone(peerId);
            }
        }
    }
}