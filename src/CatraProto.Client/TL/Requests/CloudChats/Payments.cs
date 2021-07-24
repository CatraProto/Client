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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>> GetPaymentFormAsync(int msgId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>> GetPaymentReceiptAsync(int msgId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>> ValidateRequestedInfoAsync(int msgId, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info, bool save = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(info is null) throw new ArgumentNullException(nameof(info));

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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>> SendPaymentFormAsync(int msgId, CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials, string requestedInfoId = null, string shippingOptionId = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(credentials is null) throw new ArgumentNullException(nameof(credentials));

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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase>> GetSavedInfoAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ClearSavedInfoAsync(bool credentials = true, bool info = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>> GetBankCardDataAsync(string number, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(number is null) throw new ArgumentNullException(nameof(number));

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
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}

	}
}