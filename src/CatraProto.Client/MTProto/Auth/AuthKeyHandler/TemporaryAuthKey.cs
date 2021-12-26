using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    class TemporaryAuthKey
    {
        public delegate void AuthKeyChanged(AuthKeyObject authKey, bool bindCompleted);
        public event AuthKeyChanged? OnAuthKeyChanged;
        
        private readonly PermanentAuthKey _permanentAuthKey;
        private readonly AuthKeyCache _keyCacheCache;
        private readonly ConnectionSettings _connectionSettings;
        private readonly MTProtoState _mtProtoState;
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        
        public TemporaryAuthKey(AuthKeyCache authKeyCache, ConnectionSettings connectionSettings, PermanentAuthKey permanentAuthKey, MTProtoState mtProtoState, ILogger logger)
        {
            _keyCacheCache = authKeyCache;
            _connectionSettings = connectionSettings;
            _permanentAuthKey = permanentAuthKey;
            _mtProtoState = mtProtoState;
            _logger = logger.ForContext<TemporaryAuthKey>();
        }

        public async Task GenerateNewAuthKey(CancellationToken token)
        {
            var duration = _connectionSettings.PfsKeyDuration;
            var permanentKey = await _permanentAuthKey.GetAuthKeyAsync(token);
            var success = await AuthKeyGen.EnsureComputeAsync(duration, _mtProtoState.Api, _logger, token);
            var expiresAt = (int)DateTimeOffset.Now.Add(TimeSpan.FromSeconds(duration)).ToUnixTimeSeconds();
            lock (_mutex)
            {
                _keyCacheCache.SetData(success.KeyArray, success.AuthKeyId, success.ServerSalt, expiresAt, false);
            }
            var keyObject = new AuthKeyObject(success.KeyArray, success.AuthKeyId, success.ServerSalt, expiresAt);
            _logger.Information("Generated temporary authentication key {AuthId} which expires at {Time}", success.AuthKeyId, expiresAt);
            OnAuthKeyChanged?.Invoke(keyObject, false);

            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = success.AuthKeyId,
                PermAuthKeyId = permanentKey.AuthKeyId,
                TempSessionId = _mtProtoState.SessionIdHandler.GetSessionId(),
                ExpiresAt = expiresAt
            };
            
            var messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
            var encryptedInnerData = Pfs.Encrypt(permanentKey, innerData, messageId);
            var messageOptions = new MessageSendingOptions(true, messageId);
            
            _mtProtoState.Connection.SetIsInited(false);
            await _mtProtoState.Api.CloudChatsApi.Auth.BindTempAuthKeyAsync(permanentKey.AuthKeyId, innerData.Nonce, expiresAt, encryptedInnerData, messageOptions, token);
            
            lock (_mutex)
            {
                _keyCacheCache.SetData(success.KeyArray, success.AuthKeyId, success.ServerSalt, expiresAt, true);
                OnAuthKeyChanged?.Invoke(keyObject, true);
            }
            
            _logger.Information("Temporary authentication key {AuthId} bound to permanent {PAuthId}", success.AuthKeyId, permanentKey.AuthKeyId);
            _mtProtoState.Connection.WakeUpLoop();
        }

        public void SetExpired()
        {
            lock (_mutex)
            {
                var data = _keyCacheCache.GetData();
                if (data is null)
                {
                    throw new InvalidOperationException("No cached authorization key");
                }
                
                var (authKey, authKeyId, salt, _, isBound) = data.Value;
                _keyCacheCache.SetData(authKey, authKeyId, salt, -1, isBound);
            }
        }

        public AuthKeyObject GetCachedKey()
        {
            lock (_mutex)
            {
                var data = _keyCacheCache.GetData();
                if (data is null)
                {
                    throw new InvalidOperationException("No cached authorization key");
                }

                var key = data.Value;
                return new AuthKeyObject(key.Key, key.KeyId, key.Salt, key.ExpirationDate);
            }
        }
        
        public bool HasExpired(int toSubtract = 0)
        {
            lock (_mutex)
            {
                var data = _keyCacheCache.GetData();
                if (data is null)
                {
                    return false;
                }
                
                return DateTimeOffset.Now.ToUnixTimeSeconds() - (data.Value.ExpirationDate - toSubtract) > 0;
            }
        }

        public bool IsBound()
        {
            lock (_mutex)
            {
                var data = _keyCacheCache.GetData();
                if (data is null)
                {
                    return false;
                }

                return data.Value.IsBound!.Value;   
            }
        }

        public bool CanBeUsed()
        {
            lock (_mutex)
            {
                return IsBound() && !HasExpired();
            }
        }

        public bool Exists()
        {
            lock (_mutex)
            {
                return _keyCacheCache.GetData().HasValue;
            }
        }
    }
}