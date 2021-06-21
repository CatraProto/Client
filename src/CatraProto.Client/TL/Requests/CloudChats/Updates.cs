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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>> GetState( CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase>> GetDifference(int pts, int date, int qts, int? ptsTotalLimit = null, CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase>> GetChannelDifference(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase filter, int pts, int limit, bool force = true, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}

	}
}