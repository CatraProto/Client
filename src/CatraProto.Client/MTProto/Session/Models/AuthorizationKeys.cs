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

using System.Collections.Generic;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class AuthorizationKeys : SessionModel
    {
        private readonly Dictionary<int, (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey)> _authKeys = new Dictionary<int, (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey)>();


        public AuthorizationKeys(object mutex) : base(mutex)
        {
        }

        public (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey) GetAuthKeys(int dc, out bool justCreated)
        {
            lock (Mutex)
            {
                (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey) authKey;
                if (_authKeys.TryGetValue(dc, out var outKey))
                {
                    authKey = outKey;
                    justCreated = false;
                }
                else
                {
                    var permKey = new AuthKeyCache(Mutex);
                    var tempKey = new AuthKeyCache(Mutex);
                    authKey.PermanentAuthKey = permKey;
                    authKey.TemporaryAuthKey = tempKey;
                    justCreated = true;
                    _authKeys.TryAdd(dc, authKey);
                }

                return authKey;
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                var count = reader.ReadInt32().Value;
                for (var i = 0; i < count; i++)
                {
                    var dc = reader.ReadInt32().Value;
                    var permKey = new AuthKeyCache(Mutex);
                    var tempKey = new AuthKeyCache(Mutex);
                    permKey.Read(reader);
                    tempKey.Read(reader);
                    _authKeys.TryAdd(dc, (permKey, tempKey));
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.WriteInt32(_authKeys.Count);
                foreach (var (dc, key) in _authKeys)
                {
                    writer.WriteInt32(dc);
                    key.PermanentAuthKey.Save(writer);
                    key.TemporaryAuthKey.Save(writer);
                }
            }
        }
    }
}