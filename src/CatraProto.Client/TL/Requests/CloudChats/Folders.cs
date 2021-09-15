using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Folders;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Folders
    {
        private readonly MessagesQueue _messagesQueue;

        internal Folders(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<UpdatesBase>> EditPeerFoldersAsync(IList<InputFolderPeerBase> folderPeers, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditPeerFolders
            {
                FolderPeers = folderPeers
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DeleteFolderAsync(int folderId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteFolder
            {
                FolderId = folderId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}