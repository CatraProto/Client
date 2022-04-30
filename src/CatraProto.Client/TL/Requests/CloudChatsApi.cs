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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Requests
{
    public partial class CloudChatsApi
    {

        public CatraProto.Client.TL.Requests.CloudChats.Auth Auth { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Account Account { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Users Users { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Contacts Contacts { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Messages Messages { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Updates Updates { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Photos Photos { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Upload Upload { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Help Help { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Channels Channels { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Bots Bots { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Payments Payments { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Stickers Stickers { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Phone Phone { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Langpack Langpack { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Folders Folders { get; }
        public CatraProto.Client.TL.Requests.CloudChats.Stats Stats { get; }
        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal CloudChatsApi(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;

            Auth = new CatraProto.Client.TL.Requests.CloudChats.Auth(client, messagesQueue);
            Account = new CatraProto.Client.TL.Requests.CloudChats.Account(client, messagesQueue);
            Users = new CatraProto.Client.TL.Requests.CloudChats.Users(client, messagesQueue);
            Contacts = new CatraProto.Client.TL.Requests.CloudChats.Contacts(client, messagesQueue);
            Messages = new CatraProto.Client.TL.Requests.CloudChats.Messages(client, messagesQueue);
            Updates = new CatraProto.Client.TL.Requests.CloudChats.Updates(client, messagesQueue);
            Photos = new CatraProto.Client.TL.Requests.CloudChats.Photos(client, messagesQueue);
            Upload = new CatraProto.Client.TL.Requests.CloudChats.Upload(client, messagesQueue);
            Help = new CatraProto.Client.TL.Requests.CloudChats.Help(client, messagesQueue);
            Channels = new CatraProto.Client.TL.Requests.CloudChats.Channels(client, messagesQueue);
            Bots = new CatraProto.Client.TL.Requests.CloudChats.Bots(client, messagesQueue);
            Payments = new CatraProto.Client.TL.Requests.CloudChats.Payments(client, messagesQueue);
            Stickers = new CatraProto.Client.TL.Requests.CloudChats.Stickers(client, messagesQueue);
            Phone = new CatraProto.Client.TL.Requests.CloudChats.Phone(client, messagesQueue);
            Langpack = new CatraProto.Client.TL.Requests.CloudChats.Langpack(client, messagesQueue);
            Folders = new CatraProto.Client.TL.Requests.CloudChats.Folders(client, messagesQueue);
            Stats = new CatraProto.Client.TL.Requests.CloudChats.Stats(client, messagesQueue);
        }

        public async Task<RpcResponse<IObject>> InvokeAfterMsgAsync(long msgId, IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsg()
            {
                MsgId = msgId,
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InvokeAfterMsgsAsync(List<long> msgIds, IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsgs()
            {
                MsgIds = msgIds,
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InitConnectionAsync(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query, CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase? proxy = null, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase? pparams = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InitConnection()
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

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InvokeWithLayerAsync(int layer, IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithLayer()
            {
                Layer = layer,
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InvokeWithoutUpdatesAsync(IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithoutUpdates()
            {
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InvokeWithMessagesRangeAsync(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithMessagesRange()
            {
                Range = range,
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<IObject>> InvokeWithTakeoutAsync(long takeoutId, IObject query, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<IObject>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithTakeout()
            {
                TakeoutId = takeoutId,
                Query = query,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}