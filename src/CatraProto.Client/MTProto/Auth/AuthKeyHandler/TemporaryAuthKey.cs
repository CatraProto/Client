using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class TemporaryAuthKey
    {
        private object _mutex = new object();
        private SessionIdHandler _sessionIdHandler;
        private MessageIdsHandler _messageIdsHandler;
        private PermanentAuthKey _permAuthKey;
        private Task<AuthKey> _generationTask;
        private AuthKey _tempAuthKey;
        private ILogger _logger;
        private Api _api;
        private int _expiresAt;
        private int _duration;

        public delegate void AuthKeyChanged(AuthKey authKey, bool bindCompleted);

        public event AuthKeyChanged OnAuthKeyChanged;

        public TemporaryAuthKey(Api api, MessageIdsHandler messageIdsHandler, SessionIdHandler sessionIdHandler, PermanentAuthKey permAuthKey, int duration, ILogger logger)
        {
            _api = api;
            _logger = logger.ForContext<TemporaryAuthKey>();
            _sessionIdHandler = sessionIdHandler;
            _messageIdsHandler = messageIdsHandler;
            _permAuthKey = permAuthKey;
            _duration = duration;
        }

        public Task<AuthKey> GetAuthKeyAsync(CancellationToken token = default, bool forceGeneration = false, bool onlyCached = false, bool forceReturn = false)
        {
            lock (_mutex)
            {
                if (forceReturn)
                {
                    return Task.FromResult(_tempAuthKey);
                }

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
            _tempAuthKey = new AuthKey(_api, _logger);
            await _tempAuthKey.ComputeAuthKey(_duration, token);

            var permAuthKey = await _permAuthKey.GetAuthKeyAsync(token);
            _expiresAt = (int)(DateTimeOffset.Now.ToUnixTimeSeconds() + _duration);

            OnAuthKeyChanged?.Invoke(_tempAuthKey, false);

            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = _tempAuthKey.AuthKeyId,
                PermAuthKeyId = permAuthKey.AuthKeyId,
                TempSessionId = _sessionIdHandler.GetSessionId(),
                ExpiresAt = _expiresAt
            };

            var messageId = _messageIdsHandler.ComputeMessageId();
            var encryptedInnerData = Pfs.Encrypt(permAuthKey, innerData, messageId);
            var messageOptions = new MessageOptions { SendWithMessageId = messageId };
            var bindTempAuthKey = await _api.CloudChatsApi.Auth.BindTempAuthKeyAsync(permAuthKey.AuthKeyId, innerData.Nonce, _expiresAt, encryptedInnerData, messageOptions, token);

            if (bindTempAuthKey.RpcCallFailed)
            {
                _logger.Error("PFS KEY BINDING FAILED, server returned {Error}", bindTempAuthKey.Error);
            }
            else
            {
                _logger.Information("TempAuthKey successfully ({TempId}) bound until {Time} to permanent key {PermKey}", _tempAuthKey.AuthKeyId, _expiresAt, permAuthKey.AuthKeyId);
            }

            OnAuthKeyChanged?.Invoke(_tempAuthKey, true);
            return _tempAuthKey;
        }
    }
}