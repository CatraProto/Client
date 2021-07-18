using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class TemporaryAuthKey
    {
        private object _mutex = new object();
        private Task<AuthKey> _generationTask;
        private SessionIdHandler _sessionIdHandler;
        private PermanentAuthKey _permAuthKey;
        private ILogger _logger;
        private Api _api;
        private int _expiresAt;
        private int _duration;

        public delegate void AuthKeyChanged(AuthKey authKey);

        public event AuthKeyChanged OnAuthKeyChanged;

        public TemporaryAuthKey(Api api, SessionIdHandler sessionIdHandler, PermanentAuthKey permAuthKey, int duration, ILogger logger)
        {
            _api = api;
            _logger = logger.ForContext<TemporaryAuthKey>();
            _sessionIdHandler = sessionIdHandler;
            _permAuthKey = permAuthKey;
            _duration = duration;
        }

        public Task<AuthKey> GetAuthKeyAsync(CancellationToken token = default, bool forceGeneration = false, bool onlyCached = false)
        {
            lock (_mutex)
            {
                if (onlyCached)
                {
                    return _generationTask;
                }

                if (_generationTask == null || forceGeneration)
                {
                    return _generationTask = InternalGetAuthKey(token);
                }

                if (_generationTask.IsCompleted)
                {
                    if (DateTimeOffset.Now.ToUnixTimeSeconds() - _expiresAt < _duration)
                    {
                        return _generationTask = InternalGetAuthKey(token);
                    }
                }

                return _generationTask;
            }
        }

        private async Task<AuthKey> InternalGetAuthKey(CancellationToken token = default)
        {
            var authKey = await _permAuthKey.GetAuthKeyAsync(token);
            OnAuthKeyChanged?.Invoke(authKey);
            return authKey;
            var tempAuthKey = new AuthKey(_api, _logger);
            await tempAuthKey.ComputeAuthKey(_duration, token);
            var permAuthKey = await _permAuthKey.GetAuthKeyAsync(token);

            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = tempAuthKey.AuthKeyId,
                PermAuthKeyId = permAuthKey.AuthKeyId,
                ExpiresAt = _expiresAt
            };

            throw new NotImplementedException();
        }
    }
}