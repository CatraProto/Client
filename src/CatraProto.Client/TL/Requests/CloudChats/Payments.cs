using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Payments
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Payments(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>> GetPaymentForm(int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentForm()
			{
				MsgId = msgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>> GetPaymentReceipt(int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentReceipt()
			{
				MsgId = msgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>> ValidateRequestedInfo(int msgId, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info, bool save = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidateRequestedInfo()
			{
				MsgId = msgId,
				Info = info,
				Save = save,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>> SendPaymentForm(int msgId, CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials, string requestedInfoId = null, string shippingOptionId = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm()
			{
				MsgId = msgId,
				Credentials = credentials,
				RequestedInfoId = requestedInfoId,
				ShippingOptionId = shippingOptionId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase>> GetSavedInfo( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetSavedInfo()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ClearSavedInfo(bool credentials = true, bool info = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.ClearSavedInfo()
			{
				Credentials = credentials,
				Info = info,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>> GetBankCardData(string number, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetBankCardData()
			{
				Number = number,
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