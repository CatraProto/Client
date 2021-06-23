using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Langpack
	{
		private MessagesHandler _messagesHandler;

		internal Langpack(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<LangPackDifferenceBase>> GetLangPackAsync(string langPack, string langCode,
			CancellationToken cancellationToken = default)
		{
			if (langPack is null)
			{
				throw new ArgumentNullException(nameof(langPack));
			}

			if (langCode is null)
			{
				throw new ArgumentNullException(nameof(langCode));
			}

			var rpcResponse = new RpcMessage<LangPackDifferenceBase>();
			var methodBody = new GetLangPack
			{
				LangPack = langPack,
				LangCode = langCode
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LangPackStringBase>> GetStringsAsync(string langPack, string langCode, List<string> keys,
			CancellationToken cancellationToken = default)
		{
			if (langPack is null)
			{
				throw new ArgumentNullException(nameof(langPack));
			}

			if (langCode is null)
			{
				throw new ArgumentNullException(nameof(langCode));
			}

			if (keys is null)
			{
				throw new ArgumentNullException(nameof(keys));
			}

			var rpcResponse = new RpcMessage<LangPackStringBase>();
			var methodBody = new GetStrings
			{
				LangPack = langPack,
				LangCode = langCode,
				Keys = keys
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LangPackDifferenceBase>> GetDifferenceAsync(string langPack, string langCode, int fromVersion,
			CancellationToken cancellationToken = default)
		{
			if (langPack is null)
			{
				throw new ArgumentNullException(nameof(langPack));
			}

			if (langCode is null)
			{
				throw new ArgumentNullException(nameof(langCode));
			}

			var rpcResponse = new RpcMessage<LangPackDifferenceBase>();
			var methodBody = new GetDifference
			{
				LangPack = langPack,
				LangCode = langCode,
				FromVersion = fromVersion
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LangPackLanguageBase>> GetLanguagesAsync(string langPack, CancellationToken cancellationToken = default)
		{
			if (langPack is null)
			{
				throw new ArgumentNullException(nameof(langPack));
			}

			var rpcResponse = new RpcMessage<LangPackLanguageBase>();
			var methodBody = new GetLanguages
			{
				LangPack = langPack
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LangPackLanguageBase>> GetLanguageAsync(string langPack, string langCode,
			CancellationToken cancellationToken = default)
		{
			if (langPack is null)
			{
				throw new ArgumentNullException(nameof(langPack));
			}

			if (langCode is null)
			{
				throw new ArgumentNullException(nameof(langCode));
			}

			var rpcResponse = new RpcMessage<LangPackLanguageBase>();
			var methodBody = new GetLanguage
			{
				LangPack = langPack,
				LangCode = langCode
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