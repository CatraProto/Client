using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session.Models;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class PermanentAuthKey
    {
        private readonly AuthKeyCache _authKeyCache;
        private readonly MTProtoState _state;
        private readonly ILogger _logger;

        public PermanentAuthKey(AuthKeyCache authKeyCache, MTProtoState state, ILogger logger)
        {
            _authKeyCache = authKeyCache;
            _state = state;
            _logger = logger.ForContext<PermanentAuthKey>();
        }

        public async ValueTask<AuthKeyObject?> GetAuthKeyAsync(CancellationToken cancellationToken = default)
        {
            var getData = _authKeyCache.GetData();
            if (getData is null)
            {
                var result = await new AuthKeyGen(_logger).ComputeAuthKey(-1, _state, cancellationToken);
                if (result is not null)
                {
                    _authKeyCache.SetData(result.KeyArray, result.AuthKeyId, result.ServerSalt);
                }

                return result;
            }

            var (key, keyId, serverSalt, _, _) = getData.Value;
            return new AuthKeyObject(key, keyId, serverSalt, null);
        }
    }
}