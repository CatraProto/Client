using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Folders;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Folders
	{
		private MessagesHandler _messagesHandler;

		internal Folders(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<UpdatesBase>> EditPeerFolders(List<InputFolderPeerBase> folderPeers, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new EditPeerFolders
			{
				FolderPeers = folderPeers,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UpdatesBase>> DeleteFolder(int folderId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new DeleteFolder
			{
				FolderId = folderId,
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