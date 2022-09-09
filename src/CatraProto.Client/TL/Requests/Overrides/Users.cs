/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

// ReSharper disable once CheckNamespace
namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Users
    {
        public async Task<RpcResponse<User>> GetSelfAsync(CancellationToken cancellationToken = default)
        {
            if (_client.ClientSession.SessionManager.SessionData.Authorization.GetAuthorization(out _, out var userId) is not ApiManagers.LoginState.LoggedIn || userId is null)
            {
                return RpcResponse<User>.FromError(new UnauthorizedUserError());
            }

            var req = await GetUsersAsync(new List<long>(1) { userId.Value }, cancellationToken);
            if (req.RpcCallFailed)
            {
                return RpcResponse<User>.FromError(req.Error);
            }

            if (req.Response.Count == 0)
            {
                return RpcResponse<User>.FromError(new PeerNotFoundError(userId.Value, PeerType.User));
            }

            return RpcResponse<User>.FromResult(req.Response[0]);
        }

        public async Task<RpcResponse<RpcVector<User>>> GetUsersAsync(List<long> id, CancellationToken cancellationToken = default)
        {
            var request = await _client.DatabaseManager.PeerDatabase.GetPeersAsync(id.ConvertAll(PeerId.AsUser), cancellationToken);
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
            return _client.DatabaseManager.PeerDatabase.GetFullPeerAsync<UserFull>(PeerId.AsUser(id), PeerDatabase.MaxUserFullCache, false, cancellationToken);
        }
    }
}