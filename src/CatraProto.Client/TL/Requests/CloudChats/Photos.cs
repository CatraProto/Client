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
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;


namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Photos
    {

        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Photos(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;

        }

        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>> UpdateProfilePhotoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.UpdateProfilePhoto()
            {
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>> UploadProfilePhotoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? file = null, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? video = null, double? videoStartTs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.UploadProfilePhoto()
            {
                File = file,
                Video = video,
                VideoStartTs = videoStartTs,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>> DeletePhotosAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>(
            new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>()
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.DeletePhotos()
            {
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>> GetUserPhotosAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int offset, long maxId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.GetUserPhotos()
            {
                UserId = userId,
                Offset = offset,
                MaxId = maxId,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>> GetUserPhotosAsync(long userId, int offset, long maxId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (userIdToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
            }
            var userIdResolved = userIdToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.GetUserPhotos()
            {
                UserId = userIdResolved,
                Offset = offset,
                MaxId = maxId,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}