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
	public partial class Users
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Users(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>> GetUsersAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetUsers()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserFullBase>> GetFullUserAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserFullBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetFullUser()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetSecureValueErrorsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));
if(errors is null) throw new ArgumentNullException(nameof(errors));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.SetSecureValueErrors()
			{
				Id = id,
				Errors = errors,
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