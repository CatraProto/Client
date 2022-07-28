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

using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class AuthKeyCache : SessionModel
    {
        private byte[]? _authKey;
        private long? _firstSalt;
        private long? _authKeyId;
        private int? _expirationDate;
        private bool? _isBound;
        private bool _isAuthorized;

        public AuthKeyCache(object mutex) : base(mutex)
        {
        }

        public void SetData(byte[] authKey, long authKeyId, long firstServerSalt, int? expirationDate = null, bool? isBound = null, bool? isAuthorized = null)
        {
            lock (Mutex)
            {
                _authKey = authKey;
                _authKeyId = authKeyId;
                _firstSalt = firstServerSalt;
                _expirationDate = expirationDate;
                _isBound = isBound;
                if(isAuthorized is not null)
                {
                    _isAuthorized = isAuthorized.Value;
                }
            }
        }

        public (byte[] Key, long KeyId, long Salt, int? ExpirationDate, bool? IsBound, bool IsAuthorized)? GetData()
        {
            lock (Mutex)
            {
                if (_authKeyId == null)
                {
                    return null;
                }

                return (_authKey!, _authKeyId!.Value, _firstSalt!.Value, _expirationDate, _isBound, _isAuthorized);
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                if (reader.ReadBool().Value)
                {
                    _authKey = reader.ReadBytes().Value;
                    _authKeyId = reader.ReadInt64().Value;
                    _firstSalt = reader.ReadInt64().Value;
                    var isTemp = reader.ReadBool().Value;
                    if (isTemp)
                    {
                        _expirationDate = reader.ReadInt32().Value;
                        _isBound = reader.ReadBool().Value;
                    }
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                if (_authKeyId != null)
                {
                    writer.WriteBool(true);
                    writer.WriteBytes(_authKey!);
                    writer.WriteInt64(_authKeyId!.Value);
                    writer.WriteInt64(_firstSalt!.Value);
                    if (_expirationDate.HasValue && _isBound.HasValue)
                    {
                        writer.WriteBool(true);
                        writer.WriteInt32(_expirationDate.Value);
                        writer.WriteBool(_isBound.Value);
                    }
                    else
                    {
                        writer.WriteBool(false);
                    }
                }
                else
                {
                    writer.WriteBool(false);
                }
            }
        }
    }
}