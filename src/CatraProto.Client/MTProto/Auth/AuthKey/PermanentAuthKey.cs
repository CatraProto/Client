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

using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session.Models;
using Serilog;

namespace CatraProto.Client.MTProto.Auth.AuthKey
{
    internal class PermanentAuthKey
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

            var (key, keyId, serverSalt, _, _, _) = getData.Value;
            return new AuthKeyObject(key, keyId, serverSalt, null);
        }

        public void SetAuthorized(bool isAuthorized)
        {
            var getData = _authKeyCache.GetData();
            if (getData is null)
            {
                return;
            }

            (var Key, var KeyId, var Salt, var ExpirationDate, var IsBound, var _) = getData.Value;
            _authKeyCache.SetData(Key, KeyId, Salt, ExpirationDate, IsBound, isAuthorized);
        }

        public bool IsAuthorized()
        {
            var getData = _authKeyCache.GetData();
            if (getData is null)
            {
                return false;
            }

            return getData.Value.IsAuthorized;
        }
    }
}