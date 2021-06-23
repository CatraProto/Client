using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Phone;
using PhoneCallBase = CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Phone
    {
        private MessagesHandler _messagesHandler;

        internal Phone(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<DataJSONBase>> GetCallConfigAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<DataJSONBase>();
            var methodBody = new GetCallConfig();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PhoneCallBase>> RequestCallAsync(InputUserBase userId, int randomId, byte[] gAHash,
            PhoneCallProtocolBase protocol, bool video = true, CancellationToken cancellationToken = default)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (gAHash is null)
            {
                throw new ArgumentNullException(nameof(gAHash));
            }

            if (protocol is null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new RequestCall
            {
                UserId = userId,
                RandomId = randomId,
                GAHash = gAHash,
                Protocol = protocol,
                Video = video
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PhoneCallBase>> AcceptCallAsync(InputPhoneCallBase peer, byte[] gB, PhoneCallProtocolBase protocol,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (gB is null)
            {
                throw new ArgumentNullException(nameof(gB));
            }

            if (protocol is null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new AcceptCall
            {
                Peer = peer,
                GB = gB,
                Protocol = protocol
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PhoneCallBase>> ConfirmCallAsync(InputPhoneCallBase peer, byte[] gA,
            long keyFingerprint, PhoneCallProtocolBase protocol, CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (gA is null)
            {
                throw new ArgumentNullException(nameof(gA));
            }

            if (protocol is null)
            {
                throw new ArgumentNullException(nameof(protocol));
            }

            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new ConfirmCall
            {
                Peer = peer,
                GA = gA,
                KeyFingerprint = keyFingerprint,
                Protocol = protocol
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReceivedCallAsync(InputPhoneCallBase peer,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReceivedCall
            {
                Peer = peer
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DiscardCallAsync(InputPhoneCallBase peer, int duration,
            PhoneCallDiscardReasonBase reason, long connectionId, bool video = true,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (reason is null)
            {
                throw new ArgumentNullException(nameof(reason));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new DiscardCall
            {
                Peer = peer,
                Duration = duration,
                Reason = reason,
                ConnectionId = connectionId,
                Video = video
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> SetCallRatingAsync(InputPhoneCallBase peer, int rating,
            string comment, bool userInitiative = true, CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (comment is null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new SetCallRating
            {
                Peer = peer,
                Rating = rating,
                Comment = comment,
                UserInitiative = userInitiative
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SaveCallDebugAsync(InputPhoneCallBase peer, DataJSONBase debug,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (debug is null)
            {
                throw new ArgumentNullException(nameof(debug));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveCallDebug
            {
                Peer = peer,
                Debug = debug
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SendSignalingDataAsync(InputPhoneCallBase peer, byte[] data,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SendSignalingData
            {
                Peer = peer,
                Data = data
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }
    }
}