using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Upload;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Upload
    {
        private readonly MessagesQueue _messagesQueue;

        internal Upload(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SaveFilePart
            {
                FileId = fileId,
                FilePart = filePart,
                Bytes = bytes
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<FileBase>> GetFileAsync(InputFileLocationBase location, int offset, int limit, bool precise = true,
            bool cdnSupported = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<FileBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetFile
            {
                Location = location,
                Offset = offset,
                Limit = limit,
                Precise = precise,
                CdnSupported = cdnSupported
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SaveBigFilePart
            {
                FileId = fileId,
                FilePart = filePart,
                FileTotalParts = fileTotalParts,
                Bytes = bytes
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<WebFileBase>> GetWebFileAsync(InputWebFileLocationBase location, int offset, int limit,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<WebFileBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetWebFile
            {
                Location = location,
                Offset = offset,
                Limit = limit
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<CdnFileBase>> GetCdnFileAsync(byte[] fileToken, int offset, int limit,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<CdnFileBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetCdnFile
            {
                FileToken = fileToken,
                Offset = offset,
                Limit = limit
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<FileHashBase>>> ReuploadCdnFileAsync(byte[] fileToken, byte[] requestToken,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<FileHashBase>>(
                new RpcVector<FileHashBase>()
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReuploadCdnFile
            {
                FileToken = fileToken,
                RequestToken = requestToken
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<FileHashBase>>> GetCdnFileHashesAsync(byte[] fileToken, int offset,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<FileHashBase>>(
                new RpcVector<FileHashBase>()
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetCdnFileHashes
            {
                FileToken = fileToken,
                Offset = offset
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<FileHashBase>>> GetFileHashesAsync(InputFileLocationBase location, int offset,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<FileHashBase>>(
                new RpcVector<FileHashBase>()
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetFileHashes
            {
                Location = location,
                Offset = offset
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}