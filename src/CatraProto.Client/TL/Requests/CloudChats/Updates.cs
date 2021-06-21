using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Updates
	{
		private MessagesHandler _messagesHandler;

		internal Updates(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<StateBase>> GetState(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StateBase>();
			var methodBody = new GetState();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<DifferenceBase>> GetDifference(int pts, int date, int qts, int? ptsTotalLimit = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DifferenceBase>();
			var methodBody = new GetDifference
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

		public async Task<RpcMessage<ChannelDifferenceBase>> GetChannelDifference(InputChannelBase channel, ChannelMessagesFilterBase filter, int pts, int limit, bool force = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChannelDifferenceBase>();
			var methodBody = new GetChannelDifference
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