using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Help
    {
        public async Task<RpcResponse<Config>> GetConfigAsync(CancellationToken token = default)
        {
            var config = await _client.ConfigManager.GetConfigAsync(token);
            return RpcResponse<Config>.FromResult(config);
        }
    }
}
