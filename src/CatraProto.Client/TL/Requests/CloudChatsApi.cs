using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Requests.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Requests
{
    public partial class CloudChatsApi
    {
        private MessagesHandler _messagesHandler;

        internal CloudChatsApi(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;

            Auth = new Auth(messagesHandler);
            Account = new Account(messagesHandler);
            Users = new Users(messagesHandler);
            Contacts = new Contacts(messagesHandler);
            Messages = new Messages(messagesHandler);
            Updates = new Updates(messagesHandler);
            Photos = new Photos(messagesHandler);
            Upload = new Upload(messagesHandler);
            Help = new Help(messagesHandler);
            Channels = new Channels(messagesHandler);
            Bots = new Bots(messagesHandler);
            Payments = new Payments(messagesHandler);
            Stickers = new Stickers(messagesHandler);
            Phone = new Phone(messagesHandler);
            Langpack = new Langpack(messagesHandler);
            Folders = new Folders(messagesHandler);
            Stats = new Stats(messagesHandler);
        }

        public Auth Auth { get; }
        public Account Account { get; }
        public Users Users { get; }
        public Contacts Contacts { get; }
        public Messages Messages { get; }
        public Updates Updates { get; }
        public Photos Photos { get; }
        public Upload Upload { get; }
        public Help Help { get; }
        public Channels Channels { get; }
        public Bots Bots { get; }
        public Payments Payments { get; }
        public Stickers Stickers { get; }
        public Phone Phone { get; }
        public Langpack Langpack { get; }
        public Folders Folders { get; }
        public Stats Stats { get; }

        public async Task<RpcMessage<IObject>> InvokeAfterMsg(long msgId, IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeAfterMsg
            {
                MsgId = msgId,
                Query = query,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InvokeAfterMsgs(List<long> msgIds, IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeAfterMsgs
            {
                MsgIds = msgIds,
                Query = query,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InitConnection(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query, InputClientProxyBase? proxy = null, JSONValueBase? pparams = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InitConnection
            {
                ApiId = apiId,
                DeviceModel = deviceModel,
                SystemVersion = systemVersion,
                AppVersion = appVersion,
                SystemLangCode = systemLangCode,
                LangPack = langPack,
                LangCode = langCode,
                Query = query,
                Proxy = proxy,
                Params = pparams,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InvokeWithLayer(int layer, IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeWithLayer
            {
                Layer = layer,
                Query = query,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InvokeWithoutUpdates(IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeWithoutUpdates
            {
                Query = query,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InvokeWithMessagesRange(MessageRangeBase range, IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeWithMessagesRange
            {
                Range = range,
                Query = query,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<IObject>> InvokeWithTakeout(long takeoutId, IObject query, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<IObject>();
            var methodBody = new InvokeWithTakeout
            {
                TakeoutId = takeoutId,
                Query = query,
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