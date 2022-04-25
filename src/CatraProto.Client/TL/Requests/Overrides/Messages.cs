using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Database;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Messages
    {
        public async Task<RpcResponse<RpcVector<ChatBase>>> GetChatsAsync(List<long> id, CancellationToken cancellationToken = default)
        {
            var request = await _client.DatabaseManager.PeerDatabase.GetPeersAsync(id.ConvertAll(x => PeerId.AsGroup(x)), cancellationToken);
            if (request.RpcCallFailed)
            {
                return RpcResponse<RpcVector<ChatBase>>.FromError(request.Error);
            }

            //just to make sure
            var filtered = request.Response.Where(x => x is Chat or ChatForbidden).Cast<ChatBase>();
            var list = new RpcVector<ChatBase>(filtered);
            return RpcResponse<RpcVector<ChatBase>>.FromResult(list);
        }

        public Task<RpcResponse<ChatFull>> GetFullChatAsync(long id, CancellationToken cancellationToken = default)
        {
            return _client.DatabaseManager.PeerDatabase.GetFullPeerAsync<ChatFull>(PeerId.AsGroup(id), PeerDatabase.MaxUserFullCache, cancellationToken);
        }
    }
}
