using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Payments;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Payments
    {
        private readonly MessagesQueue _messagesQueue;

        internal Payments(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<PaymentFormBase>> GetPaymentFormAsync(int msgId, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PaymentFormBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetPaymentForm
            {
                MsgId = msgId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<PaymentReceiptBase>> GetPaymentReceiptAsync(int msgId, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PaymentReceiptBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetPaymentReceipt
            {
                MsgId = msgId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ValidatedRequestedInfoBase>> ValidateRequestedInfoAsync(int msgId, PaymentRequestedInfoBase info,
            bool save = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ValidatedRequestedInfoBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ValidateRequestedInfo
            {
                MsgId = msgId,
                Info = info,
                Save = save
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<PaymentResultBase>> SendPaymentFormAsync(int msgId, InputPaymentCredentialsBase credentials,
            string? requestedInfoId = null, string? shippingOptionId = null, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PaymentResultBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SendPaymentForm
            {
                MsgId = msgId,
                Credentials = credentials,
                RequestedInfoId = requestedInfoId,
                ShippingOptionId = shippingOptionId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SavedInfoBase>> GetSavedInfoAsync(MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SavedInfoBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetSavedInfo();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ClearSavedInfoAsync(bool credentials = true, bool info = true,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ClearSavedInfo
            {
                Credentials = credentials,
                Info = info
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<BankCardDataBase>> GetBankCardDataAsync(string number, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<BankCardDataBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetBankCardData
            {
                Number = number
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}