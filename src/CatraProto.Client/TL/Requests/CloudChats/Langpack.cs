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
	public partial class Langpack
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Langpack(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetLangPack(string langPack, string langCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLangPack()
			{
				LangPack = langPack,
				LangCode = langCode,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>> GetStrings(string langPack, string langCode, List<string> keys, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetStrings()
			{
				LangPack = langPack,
				LangCode = langCode,
				Keys = keys,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetDifference(string langPack, string langCode, int fromVersion, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetDifference()
			{
				LangPack = langPack,
				LangCode = langCode,
				FromVersion = fromVersion,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>> GetLanguages(string langPack, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguages()
			{
				LangPack = langPack,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>> GetLanguage(string langPack, string langCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguage()
			{
				LangPack = langPack,
				LangCode = langCode,
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