using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler.Results;
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

        public async ValueTask<AuthKeyResult> GetAuthKeyAsync(CancellationToken cancellationToken = default)
        {
            var getData = _authKeyCache.GetData();
            if (getData is null)
            {
                var result = await AuthKeyGen.ComputeAuthKey(-1, _state, _logger, cancellationToken);
                if (result is AuthKeySuccess success)
                {
                    _authKeyCache.SetData(success.KeyArray, success.AuthKeyId, success.ServerSalt);
                }

                return result;
            }

            var (key, keyId, serverSalt, _, _) = getData.Value;
            return new AuthKeySuccess(key, keyId, serverSalt, null);
        }
    }
}