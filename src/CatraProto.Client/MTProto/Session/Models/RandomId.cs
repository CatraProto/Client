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

using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class RandomId : SessionModel
    {
        private readonly object _mutex;
        private long _lastId = CryptoTools.CreateRandomInt();

        public RandomId(object mutex) : base(mutex)
        {
            _mutex = mutex;
        }

        public long GetNextId()
        {
            lock (_mutex)
            {
                return ++_lastId;
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _lastId += reader.ReadInt64().Value;
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                writer.WriteInt64(_lastId);
            }
        }
    }
}