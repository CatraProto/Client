using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session.Models;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class PermanentAuthKey
    {
        private readonly AuthKey _authKey;
        private readonly AuthKeyData _authKeyData;

        public PermanentAuthKey(ConnectionInfo connectionInfo, SessionData sessionData, Api api, ILogger logger)
        {
            var authKeyData = sessionData.AuthorizationKeys.GetAuthKey(connectionInfo.DcId, out var justCreated);
            if (!justCreated)
            {
                var (key, keyId, salt) = authKeyData.GetData()!.Value;
                _authKey = new AuthKey(key, keyId, salt, api, logger);
            }
            else
            {
                _authKey = new AuthKey(api, logger);
            }

            _authKeyData = authKeyData;
        }

        public async Task<AuthKey> GetAuthKeyAsync(CancellationToken cancellationToken = default)
        {
            if (_authKey.RawAuthKey is null)
            {
                await _authKey.EnsureComputeAsync(-1, cancellationToken);
                _authKeyData.SetData(_authKey.RawAuthKey!, _authKey.AuthKeyId!.Value, _authKey.ServerSalt!.Value);
            }

            return _authKey;
        }
    }
}