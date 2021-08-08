using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.Settings;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class TemporaryAuthKey
    {
        public delegate void AuthKeyChanged(AuthKey authKey, bool bindCompleted);

        private readonly PermanentAuthKey _permanentAuthKey;
        private readonly ClientSettings _clientSettings;
        private readonly object _mutex = new object();
        private readonly MTProtoState _mtProtoState;
        private Task<AuthKey>? _generationTask;
        private readonly ILogger _logger;
        private readonly int _duration;
        private AuthKey? _tempAuthKey;
        private readonly Api _api;
        private int _expiresAt;
        public event AuthKeyChanged? OnAuthKeyChanged;

        public TemporaryAuthKey(MTProtoState mtProtoState, PermanentAuthKey permanentAuthKey, Api api, ClientSettings clientSettings, int duration, ILogger logger)
        {
            _logger = logger.ForContext<TemporaryAuthKey>();
            _mtProtoState = mtProtoState;
            _permanentAuthKey = permanentAuthKey;
            _duration = duration;
            _api = api;
            _clientSettings = clientSettings;
        }

        public Task<AuthKey> GetAuthKeyAsync(bool forceGeneration = false, bool onlyCached = false, bool forceReturn = false, CancellationToken token = default)
        {
            lock (_mutex)
            {
                if (forceReturn)
                {
                    return Task.FromResult(_tempAuthKey!);
                }

                if (onlyCached)
                {
                    return _generationTask!;
                }

                if (_generationTask is null || forceGeneration)
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
            var permAuthKey = await _permanentAuthKey.GetAuthKeyAsync(token);

            _tempAuthKey = new AuthKey(_api, _logger);
            await _tempAuthKey.ComputeAuthKey(_duration, token);

            _expiresAt = (int)(DateTimeOffset.Now.ToUnixTimeSeconds() + _duration);

            OnAuthKeyChanged?.Invoke(_tempAuthKey, false);
            _logger.Information("Binding temp auth key with permanent auth key");

            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = _tempAuthKey.AuthKeyId!.Value,
                PermAuthKeyId = permAuthKey.AuthKeyId!.Value,
                TempSessionId = _mtProtoState.SessionIdHandler.GetSessionId(),
                ExpiresAt = _expiresAt
            };

            var messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
            var encryptedInnerData = Pfs.Encrypt(permAuthKey, innerData, messageId);
            var messageOptions = new MessageSendingOptions(true, _tempAuthKey, messageId);
            var bindTempAuthKey = await _mtProtoState.Api.CloudChatsApi.Auth.BindTempAuthKeyAsync(permAuthKey.AuthKeyId.Value, innerData.Nonce, _expiresAt, encryptedInnerData, messageOptions, token);

            if (bindTempAuthKey.RpcCallFailed)
            {
                _logger.Error("PFS KEY BINDING FAILED, server returned {Error}", bindTempAuthKey.Error);
            }
            else
            {
                _logger.Information("TempAuthKey successfully ({TempId}) bound until {Time} to permanent key {PermKey}", _tempAuthKey.AuthKeyId, _expiresAt, permAuthKey.AuthKeyId);
            }


            _logger.Information("Writing client information");
            OnAuthKeyChanged?.Invoke(_tempAuthKey, true);

            var apiSettings = _clientSettings.ApiSettings;
            var response = await _mtProtoState.Api.CloudChatsApi.InvokeWithLayerAsync(121, new InitConnection
            {
                ApiId = apiSettings.ApiId,
                AppVersion = apiSettings.AppVersion,
                DeviceModel = apiSettings.DeviceModel,
                LangCode = apiSettings.LangCode,
                LangPack = apiSettings.LangPack,
                SystemLangCode = apiSettings.SystemLangCode,
                SystemVersion = apiSettings.SystemVersion,
                Query = new GetConfig()
            }, cancellationToken: token, messageSendingOptions: new MessageSendingOptions(true, _tempAuthKey));

            if (response.Error != null)
            {
                _logger.Error("Couldn't write client information due to {Error}", bindTempAuthKey.Error);
            }
            else
            {
                _logger.Information("Successfully wrote client information");
            }

            return _tempAuthKey;
        }
    }
}