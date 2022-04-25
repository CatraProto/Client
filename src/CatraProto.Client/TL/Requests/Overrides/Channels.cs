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
    public partial class Channels
    {
        public async Task<RpcResponse<RpcVector<ChatBase>>> GetChannelsAsync(List<long> id, CancellationToken cancellationToken = default)
        {
            var request = await _client.DatabaseManager.PeerDatabase.GetPeersAsync(id.ConvertAll(x => PeerId.AsChannel(x)), cancellationToken);
            if (request.RpcCallFailed)
            {
                return RpcResponse<RpcVector<ChatBase>>.FromError(request.Error);
            }

            //just to make sure
            var filtered = request.Response.Where(x => x is Channel or ChannelForbidden).Cast<ChatBase>();
            var list = new RpcVector<ChatBase>(filtered);
            return RpcResponse<RpcVector<ChatBase>>.FromResult(list);
        }

        public Task<RpcResponse<ChannelFull>> GetFullChannelAsync(long id, CancellationToken cancellationToken = default)
        {
            return _client.DatabaseManager.PeerDatabase.GetFullPeerAsync<ChannelFull>(PeerId.AsChannel(id), PeerDatabase.MaxChannelFullCache, cancellationToken);
        }
    }
}
