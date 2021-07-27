using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class TemporaryAuthKey
    {
        public bool IsBound { get; set; }
        private object _mutex = new object();
        private ConnectionState _connectionState;
        private Task<AuthKey> _generationTask;
        private AuthKey _tempAuthKey;
        private ILogger _logger;
        private int _expiresAt;
        private int _duration;

        public delegate void AuthKeyChanged(AuthKey authKey, bool bindCompleted);

        public event AuthKeyChanged OnAuthKeyChanged;

        public TemporaryAuthKey(ConnectionState connectionState, int duration, ILogger logger)
        {
            _logger = logger.ForContext<TemporaryAuthKey>();
            _connectionState = connectionState;
            _duration = duration;
        }

        public Task<AuthKey> GetAuthKeyAsync(bool forceGeneration = false, bool onlyCached = false, bool forceReturn = false, CancellationToken token = default)
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
                    return _generationTask = InternalGetAuthKeyAsync(token);
                }

                if (_generationTask.IsCompleted)
                {
                    if (DateTimeOffset.Now.ToUnixTimeSeconds() - _expiresAt >= _duration)
                    {
                        return _generationTask = InternalGetAuthKeyAsync(token);
                    }
                }

                return _generationTask;
            }
        }

        private async Task<AuthKey> InternalGetAuthKeyAsync(CancellationToken token = default)
        {
            _tempAuthKey = new AuthKey(_connectionState.Api, _logger);
            await _tempAuthKey.ComputeAuthKey(_duration, token);

            var permAuthKey = await _connectionState.PermanentAuthKey.GetAuthKeyAsync(token);
            _expiresAt = (int)(DateTimeOffset.Now.ToUnixTimeSeconds() + _duration);

            OnAuthKeyChanged?.Invoke(_tempAuthKey, false);

            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = _tempAuthKey.AuthKeyId,
                PermAuthKeyId = permAuthKey.AuthKeyId,
                TempSessionId = _connectionState.SessionIdHandler.GetSessionId(),
                ExpiresAt = _expiresAt
            };

            var messageId = _connectionState.MessageIdsHandler.ComputeMessageId();
            var encryptedInnerData = Pfs.Encrypt(permAuthKey, innerData, messageId);
            var messageOptions = new MessageSendingOptions { SendWithMessageId = messageId };
            var bindTempAuthKey = await _connectionState.Api.CloudChatsApi.Auth.BindTempAuthKeyAsync(permAuthKey.AuthKeyId, innerData.Nonce, _expiresAt, encryptedInnerData, messageOptions, token);

            if (bindTempAuthKey.RpcCallFailed)
            {
                _logger.Error("PFS KEY BINDING FAILED, server returned {Error}", bindTempAuthKey.Error);
            }
            else
            {
                _logger.Information("TempAuthKey successfully ({TempId}) bound until {Time} to permanent key {PermKey}", _tempAuthKey.AuthKeyId, _expiresAt, permAuthKey.AuthKeyId);
            }

            var apiSettings = _connectionState.Settings.ApiSettings;
            await _connectionState.Api.CloudChatsApi.InvokeWithLayerAsync(121, new InitConnection
            {
                ApiId = apiSettings.ApiId,
                AppVersion = apiSettings.AppVersion,
                DeviceModel = apiSettings.DeviceModel,
                LangCode = apiSettings.LangCode,
                LangPack = apiSettings.LangPack,
                SystemLangCode = apiSettings.SystemLangCode,
                SystemVersion = apiSettings.SystemVersion,
                Query = new GetConfig()
            });
            OnAuthKeyChanged?.Invoke(_tempAuthKey, true);
            return _tempAuthKey;
        }
    }
}