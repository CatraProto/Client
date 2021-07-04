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
	public partial class Bots
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Bots(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>> SendCustomRequestAsync(string customMethod, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams, CancellationToken cancellationToken = default)
		{
			if(customMethod is null) throw new ArgumentNullException(nameof(customMethod));
if(pparams is null) throw new ArgumentNullException(nameof(pparams));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.SendCustomRequest()
			{
				CustomMethod = customMethod,
				Params = pparams,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> AnswerWebhookJSONQueryAsync(long queryId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data, CancellationToken cancellationToken = default)
		{
			if(data is null) throw new ArgumentNullException(nameof(data));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.AnswerWebhookJSONQuery()
			{
				QueryId = queryId,
				Data = data,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetBotCommandsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands, CancellationToken cancellationToken = default)
		{
			if(commands is null) throw new ArgumentNullException(nameof(commands));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotCommands()
			{
				Commands = commands,
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