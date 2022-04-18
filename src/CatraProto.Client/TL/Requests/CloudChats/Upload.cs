using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;


namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Upload
    {

        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Upload(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;

        }

        public async Task<RpcResponse<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveFilePart()
            {
                FileId = fileId,
                FilePart = filePart,
                Bytes = bytes,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>> GetFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, int limit, bool precise = false, bool cdnSupported = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFile()
            {
                Location = location,
                Offset = offset,
                Limit = limit,
                Precise = precise,
                CdnSupported = cdnSupported,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveBigFilePart()
            {
                FileId = fileId,
                FilePart = filePart,
                FileTotalParts = fileTotalParts,
                Bytes = bytes,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>> GetWebFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase location, int offset, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetWebFile()
            {
                Location = location,
                Offset = offset,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>> GetCdnFileAsync(byte[] fileToken, int offset, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFile()
            {
                FileToken = fileToken,
                Offset = offset,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> ReuploadCdnFileAsync(byte[] fileToken, byte[] requestToken, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>(
            new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>()
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.ReuploadCdnFile()
            {
                FileToken = fileToken,
                RequestToken = requestToken,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetCdnFileHashesAsync(byte[] fileToken, int offset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>(
            new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>()
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFileHashes()
            {
                FileToken = fileToken,
                Offset = offset,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetFileHashesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>(
            new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>()
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFileHashes()
            {
                Location = location,
                Offset = offset,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}