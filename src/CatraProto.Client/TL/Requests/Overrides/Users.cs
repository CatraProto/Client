using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Database;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.Database;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Users
    {
        public async Task<RpcResponse<RpcVector<User>>> GetUsersAsync(List<long> users, CancellationToken cancellationToken = default)
        {
            var result = new RpcVector<User>();
            var inputUsers = new List<InputUserBase>();
            foreach (var userId in users)
            {
                var getPeer = _client.DatabaseManager.PeerDatabase.GetPeerObject(PeerId.AsUser(userId), false);
                if (getPeer is null || getPeer is not DbPeer peer || peer.Object is null || peer.Object is not User)
                {
                    var inputUser = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
                    if (inputUser is null)
                    {
                        continue;
                    }

                    inputUsers.Add(inputUser);
                }
                else
                {
                    result.Add((User)peer.Object);
                }
            }

            if (inputUsers.Count > 0)
            {
                var userRequest = await InternalGetUsersAsync(inputUsers, cancellationToken: cancellationToken);
                if (userRequest.RpcCallFailed)
                {
                    return RpcResponse<RpcVector<User>>.FromError(userRequest.Error);
                }

                result.AddRange(userRequest.Response.Where(x => x is User).Cast<User>());
            }

            return RpcResponse<RpcVector<User>>.FromResult(result);
        }

        public async Task<RpcResponse<UserFullBase>> GetFullUserAsync(long id, CancellationToken cancellationToken = default)
        {
            var getPeer = _client.DatabaseManager.PeerDatabase.GetPeerObject(PeerId.AsUser(id), true);
            if (getPeer is null || getPeer is not DbPeerFull peer || peer.Object is null || peer.Object is not UserFull || DateTimeOffset.UtcNow.ToUnixTimeSeconds() - peer.UpdatedAt > PeerDatabase.MaxUserFullCache)
            {
                var inputUser = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
                if (inputUser is null)
                {
                    return RpcResponse<UserFullBase>.FromError(new PeerNotFoundError(id, PeerType.User));
                }
                else
                {
                    var fetchFull = await InternalGetFullUserAsync(inputUser, cancellationToken: cancellationToken);
                    if (fetchFull.RpcCallFailed)
                    {
                        return RpcResponse<UserFullBase>.FromError(fetchFull.Error);
                    }

                    return RpcResponse<UserFullBase>.FromResult(fetchFull.Response.FullUser);
                }
            }
            else
            {
                return RpcResponse<UserFullBase>.FromResult((UserFull)peer.Object);
            }
        }
    }
}
