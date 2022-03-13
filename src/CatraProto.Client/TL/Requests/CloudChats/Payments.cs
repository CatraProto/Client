using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using CatraProto.Client;
using CatraProto.Client.MTProto.Rpc.RpcErrors.CatraErrors;
using System.Collections.Generic;
using System.Numerics;


namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Payments
	{
		
	    private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Payments(TelegramClient client, MessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>> GetPaymentFormAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentForm(){
Peer = peer,
MsgId = msgId,
ThemeParams = themeParams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>> GetPaymentReceiptAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentReceipt(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>> ValidateRequestedInfoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info, bool save = true, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidateRequestedInfo(){
Peer = peer,
MsgId = msgId,
Info = info,
Save = save,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>> SendPaymentFormAsync(long formId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials, string? requestedInfoId = null, string? shippingOptionId = null, long? tipAmount = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm(){
FormId = formId,
Peer = peer,
MsgId = msgId,
Credentials = credentials,
RequestedInfoId = requestedInfoId,
ShippingOptionId = shippingOptionId,
TipAmount = tipAmount,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase>> GetSavedInfoAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetSavedInfo(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ClearSavedInfoAsync(bool credentials = true, bool info = true, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.ClearSavedInfo(){
Credentials = credentials,
Info = info,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>> GetBankCardDataAsync(string number, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetBankCardData(){
Number = number,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>> GetPaymentFormAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>.FromError(new CantResolvePeer(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentFormBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentForm(){
Peer = peerResolved,
MsgId = msgId,
ThemeParams = themeParams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>> GetPaymentReceiptAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>.FromError(new CantResolvePeer(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.GetPaymentReceipt(){
Peer = peerResolved,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>> ValidateRequestedInfoAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info, bool save = true, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>.FromError(new CantResolvePeer(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidatedRequestedInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.ValidateRequestedInfo(){
Peer = peerResolved,
MsgId = msgId,
Info = info,
Save = save,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>> SendPaymentFormAsync(long formId, CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials, string? requestedInfoId = null, string? shippingOptionId = null, long? tipAmount = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>.FromError(new CantResolvePeer(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Payments.SendPaymentForm(){
FormId = formId,
Peer = peerResolved,
MsgId = msgId,
Credentials = credentials,
RequestedInfoId = requestedInfoId,
ShippingOptionId = shippingOptionId,
TipAmount = tipAmount,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}