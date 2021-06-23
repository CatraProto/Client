using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Payments;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Payments
	{
		private MessagesHandler _messagesHandler;

		internal Payments(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<PaymentFormBase>> GetPaymentFormAsync(int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PaymentFormBase>();
			var methodBody = new GetPaymentForm
			{
				MsgId = msgId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PaymentReceiptBase>> GetPaymentReceiptAsync(int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PaymentReceiptBase>();
			var methodBody = new GetPaymentReceipt
			{
				MsgId = msgId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<ValidatedRequestedInfoBase>> ValidateRequestedInfoAsync(int msgId, PaymentRequestedInfoBase info,
			bool save = true, CancellationToken cancellationToken = default)
		{
			if (info is null)
			{
				throw new ArgumentNullException(nameof(info));
			}

			var rpcResponse = new RpcMessage<ValidatedRequestedInfoBase>();
			var methodBody = new ValidateRequestedInfo
			{
				MsgId = msgId,
				Info = info,
				Save = save
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PaymentResultBase>> SendPaymentFormAsync(int msgId, InputPaymentCredentialsBase credentials,
			string requestedInfoId = null, string shippingOptionId = null, CancellationToken cancellationToken = default)
		{
			if (credentials is null)
			{
				throw new ArgumentNullException(nameof(credentials));
			}

			var rpcResponse = new RpcMessage<PaymentResultBase>();
			var methodBody = new SendPaymentForm
			{
				MsgId = msgId,
				Credentials = credentials,
				RequestedInfoId = requestedInfoId,
				ShippingOptionId = shippingOptionId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SavedInfoBase>> GetSavedInfoAsync(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SavedInfoBase>();
			var methodBody = new GetSavedInfo();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> ClearSavedInfoAsync(bool credentials = true, bool info = true,
			CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ClearSavedInfo
			{
				Credentials = credentials,
				Info = info
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<BankCardDataBase>> GetBankCardDataAsync(string number, CancellationToken cancellationToken = default)
		{
			if (number is null)
			{
				throw new ArgumentNullException(nameof(number));
			}

			var rpcResponse = new RpcMessage<BankCardDataBase>();
			var methodBody = new GetBankCardData
			{
				Number = number
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