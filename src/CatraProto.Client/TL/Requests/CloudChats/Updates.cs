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
	public partial class Updates
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Updates(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>> GetStateAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetState()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase>> GetDifferenceAsync(int pts, int date, int qts, int? ptsTotalLimit = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetDifference()
			{
				Pts = pts,
				Date = date,
				Qts = qts,
				PtsTotalLimit = ptsTotalLimit,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase>> GetChannelDifferenceAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase filter, int pts, int limit, bool force = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(filter is null) throw new ArgumentNullException(nameof(filter));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Updates.GetChannelDifference()
			{
				Channel = channel,
				Filter = filter,
				Pts = pts,
				Limit = limit,
				Force = force,
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