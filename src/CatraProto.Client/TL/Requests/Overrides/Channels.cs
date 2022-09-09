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
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;

// ReSharper disable once CheckNamespace
namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Channels
    {
        public async Task<RpcResponse<RpcVector<ChatBase>>> GetChannelsAsync(List<long> id, CancellationToken cancellationToken = default)
        {
            var request = await _client.DatabaseManager.PeerDatabase.GetPeersAsync(id.ConvertAll(PeerId.AsChannel), cancellationToken);
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
            return _client.DatabaseManager.PeerDatabase.GetFullPeerAsync<ChannelFull>(PeerId.AsChannel(id), PeerDatabase.MaxChannelFullCache, false, cancellationToken);
        }
    }
}