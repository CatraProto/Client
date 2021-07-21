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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetLangPackAsync(string langPack, string langCode, CancellationToken cancellationToken = default)
		{
			if(langPack is null) throw new ArgumentNullException(nameof(langPack));
if(langCode is null) throw new ArgumentNullException(nameof(langCode));

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
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>>> GetStringsAsync(string langPack, string langCode, IList<string> keys, CancellationToken cancellationToken = default)
		{
			if(langPack is null) throw new ArgumentNullException(nameof(langPack));
if(langCode is null) throw new ArgumentNullException(nameof(langCode));
if(keys is null) throw new ArgumentNullException(nameof(keys));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetDifferenceAsync(string langPack, string langCode, int fromVersion, CancellationToken cancellationToken = default)
		{
			if(langPack is null) throw new ArgumentNullException(nameof(langPack));
if(langCode is null) throw new ArgumentNullException(nameof(langCode));

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
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>>> GetLanguagesAsync(string langPack, CancellationToken cancellationToken = default)
		{
			if(langPack is null) throw new ArgumentNullException(nameof(langPack));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>> GetLanguageAsync(string langPack, string langCode, CancellationToken cancellationToken = default)
		{
			if(langPack is null) throw new ArgumentNullException(nameof(langPack));
if(langCode is null) throw new ArgumentNullException(nameof(langCode));

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