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
	public partial class Stats
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Stats(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>> GetBroadcastStats(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool dark = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetBroadcastStats()
			{
				Channel = channel,
				Dark = dark,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>> LoadAsyncGraph(string token, long? x = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.LoadAsyncGraph()
			{
				Token = token,
				X = x,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>> GetMegagroupStats(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool dark = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMegagroupStats()
			{
				Channel = channel,
				Dark = dark,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagePublicForwards(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int msgId, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessagePublicForwards()
			{
				Channel = channel,
				MsgId = msgId,
				OffsetRate = offsetRate,
				OffsetPeer = offsetPeer,
				OffsetId = offsetId,
				Limit = limit,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>> GetMessageStats(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int msgId, bool dark = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessageStats()
			{
				Channel = channel,
				MsgId = msgId,
				Dark = dark,
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