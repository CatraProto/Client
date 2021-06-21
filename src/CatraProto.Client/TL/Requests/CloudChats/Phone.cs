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
    public partial class Phone
    {
        private MessagesHandler _messagesHandler;

        internal Phone(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<DataJSONBase>> GetCallConfig(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<PhoneCallBase>> RequestCall(InputUserBase userId, int randomId, byte[] gAHash, PhoneCallProtocolBase protocol, bool video = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new RequestCall
            {
                UserId = userId,
                RandomId = randomId,
                GAHash = gAHash,
                Protocol = protocol,
                Video = video,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PhoneCallBase>> AcceptCall(InputPhoneCallBase peer, byte[] gB, PhoneCallProtocolBase protocol, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new AcceptCall
            {
                Peer = peer,
                GB = gB,
                Protocol = protocol,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PhoneCallBase>> ConfirmCall(InputPhoneCallBase peer, byte[] gA, long keyFingerprint, PhoneCallProtocolBase protocol, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PhoneCallBase>();
            var methodBody = new ConfirmCall
            {
                Peer = peer,
                GA = gA,
                KeyFingerprint = keyFingerprint,
                Protocol = protocol,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReceivedCall(InputPhoneCallBase peer, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReceivedCall
            {
                Peer = peer,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DiscardCall(InputPhoneCallBase peer, int duration, PhoneCallDiscardReasonBase reason, long connectionId, bool video = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new DiscardCall
            {
                Peer = peer,
                Duration = duration,
                Reason = reason,
                ConnectionId = connectionId,
                Video = video,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> SetCallRating(InputPhoneCallBase peer, int rating, string comment, bool userInitiative = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new SetCallRating
            {
                Peer = peer,
                Rating = rating,
                Comment = comment,
                UserInitiative = userInitiative,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SaveCallDebug(InputPhoneCallBase peer, DataJSONBase debug, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveCallDebug
            {
                Peer = peer,
                Debug = debug,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SendSignalingData(InputPhoneCallBase peer, byte[] data, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SendSignalingData
            {
                Peer = peer,
                Data = data,
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