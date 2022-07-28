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

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKey
{
    internal class TemporaryAuthKey
    {
        public event KeyGenerated? OnKeyGenerated;
        public delegate void KeyGenerated();

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

        public async Task<bool> GenerateNewAuthKey(CancellationToken token)
        {
            var duration = _connectionSettings.PfsKeyDuration;
            var permanentKey = await _permanentAuthKey.GetAuthKeyAsync(token);
            if (permanentKey is null)
            {
                return false;
            }

            var keyObject = await new AuthKeyGen(_logger).ComputeAuthKey(duration, _mtProtoState, token);
            if (keyObject is null)
            {
                return false;
            }

            var expiresAt = (int)DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(duration)).ToUnixTimeSeconds();
            lock (_mutex)
            {
                _keyCacheCache.SetData(keyObject.KeyArray, keyObject.AuthKeyId, keyObject.ServerSalt, expiresAt, false);
            }

            _logger.Information("Generated temporary authentication key {AuthId} which expires at {Time}", keyObject.AuthKeyId, expiresAt);
            await _mtProtoState.Connection.ResetSessionAsync(true, keyObject.ServerSalt);
            var innerData = new BindAuthKeyInner
            {
                Nonce = CryptoTools.CreateRandomLong(),
                TempAuthKeyId = keyObject.AuthKeyId,
                PermAuthKeyId = permanentKey.AuthKeyId,
                TempSessionId = _mtProtoState.SessionIdHandler.GetSessionId(out _),
                ExpiresAt = expiresAt
            };

            var messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
            var encryptedInnerData = EncryptPfsPayload(permanentKey, innerData, messageId);
            if (encryptedInnerData is null)
            {
                return false;
            }

            var messageOptions = new MessageSendingOptions(true, messageId);
            var res = await _mtProtoState.Api.CloudChatsApi.Auth.BindTempAuthKeyAsync(permanentKey.AuthKeyId, innerData.Nonce, expiresAt, encryptedInnerData, messageOptions, token);
            if (res.RpcCallFailed)
            {
                _logger.Error("Failed to bind authorization key. Error {error}", res.Error);
                SetExpired();
                return false;
            }

            lock (_mutex)
            {
                _keyCacheCache.SetData(keyObject.KeyArray, keyObject.AuthKeyId, keyObject.ServerSalt, expiresAt, true);
            }

            _logger.Information("Temporary authentication key {AuthId} bound to permanent {PAuthId}", keyObject.AuthKeyId, permanentKey.AuthKeyId);
            OnKeyGenerated?.Invoke();
            return true;
        }

        private byte[]? EncryptPfsPayload(AuthKeyObject permAuthKey, BindAuthKeyInner inner, long messageId)
        {
            using (var encryptedWriter = new BinaryWriter(new MemoryStream()))
            {
                using (var plainWriter = new BinaryWriter(new MemoryStream()))
                {
                    var trySer = inner.ToArray(MergedProvider.Singleton, out var serializedPayload);
                    if (trySer.IsError)
                    {
                        _logger.Error("Could not TL-serialize BindAuthKeyInner. Error: {Error}", trySer.GetError().Error);
                        return null;
                    }

                    plainWriter.Write(CryptoTools.GenerateRandomBytes(16));
                    plainWriter.Write(messageId);
                    plainWriter.Write(0);
                    plainWriter.Write(40);
                    plainWriter.Write(serializedPayload);

                    var plainToByte = ((MemoryStream)plainWriter.BaseStream).ToArray();
                    var msgKey = SHA1.HashData(plainToByte).Skip(4).Take(16).ToArray();

                    CryptoTools.AddPadding(plainWriter.BaseStream, 16);
                    plainToByte = ((MemoryStream)plainWriter.BaseStream).ToArray();

                    using var encryptor = AesCryptoCreator.CreateEncryptorV1(permAuthKey.KeyArray, msgKey, true);
                    var encryptedData = encryptor.Encrypt(plainToByte);

                    encryptedWriter.Write(permAuthKey.AuthKeyId);
                    encryptedWriter.Write(msgKey);
                    encryptedWriter.Write(encryptedData);
                }

                return ((MemoryStream)encryptedWriter.BaseStream).ToArray();
            }
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

                var (authKey, authKeyId, salt, _, isBound, _) = data.Value;
                _keyCacheCache.SetData(authKey, authKeyId, salt, -1, isBound);
            }
        }

        public bool SetExpiredSafe()
        {
            lock (_mutex)
            {
                if (!HasExpired())
                {
                    SetExpired();
                    return true;
                }
                return false;
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
                    return true;
                }

                return DateTimeOffset.UtcNow.ToUnixTimeSeconds() - (data.Value.ExpirationDate - toSubtract) >= 0;
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