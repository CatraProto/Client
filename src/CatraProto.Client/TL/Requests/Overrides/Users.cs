﻿using System.Collections.Generic;
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
    public partial class Users
    {
        public async Task<RpcResponse<RpcVector<User>>> GetUsersAsync(List<long> id, CancellationToken cancellationToken = default)
        {
            var request = await _client.DatabaseManager.PeerDatabase.GetPeersAsync(id.ConvertAll(x => PeerId.AsUser(x)), cancellationToken);
            if (request.RpcCallFailed)
            {
                return RpcResponse<RpcVector<User>>.FromError(request.Error);
            }

            //just to make sure
            var filtered = request.Response.Where(x => x is User).Cast<User>();
            var list = new RpcVector<User>(filtered);
            return RpcResponse<RpcVector<User>>.FromResult(list);
        }

        public Task<RpcResponse<UserFull>> GetFullUserAsync(long id, CancellationToken cancellationToken = default)
        {
            return _client.DatabaseManager.PeerDatabase.GetFullPeerAsync<UserFull>(PeerId.AsUser(id), PeerDatabase.MaxUserFullCache, cancellationToken);
        }
    }
}
