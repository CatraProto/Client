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
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class Authorization : SessionModel, IDisposable
    {
        private readonly AsyncSignaler _asyncSignaler = new AsyncSignaler(false);
        private long _userAccessHash;
        private long _userId;
        private int _dcId;

        public Authorization(object mutex) : base(mutex)
        {
        }

        public void SetAuthorized(bool authorized, int dcId, long userId, long userAccessHash)
        {
            lock (Mutex)
            {
                _userAccessHash = userAccessHash;
                _userId = userId;
                _dcId = dcId;
                _asyncSignaler.SetSignal(authorized);
                OnDataUpdated();
            }
        }

        public bool IsAuthorized(out int? dcId, out long? userId, out long? userAccessHash)
        {
            lock (Mutex)
            {
                if (_asyncSignaler.IsReleased())
                {
                    dcId = _dcId;
                    userId = _userId;
                    userAccessHash = _userAccessHash;
                    return true;
                }

                dcId = null;
                userId = null;
                userAccessHash = null;
                return false;
            }
        }

        public async Task WaitAuthorizationAsync()
        {
            Task task;
            lock (Mutex)
            {
                if (_asyncSignaler.IsReleased())
                {
                    return;
                }

                task = _asyncSignaler.WaitAsync();
            }

            await task;
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _asyncSignaler.SetSignal(reader.ReadBool().Value);
                if (_asyncSignaler.IsReleased())
                {
                    _dcId = reader.ReadInt32().Value;
                    _userId = reader.ReadInt64().Value;
                    _userAccessHash = reader.ReadInt64().Value;
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                var isAuth = IsAuthorized(out var dcId, out var userId, out var userAccessHash);
                writer.WriteBool(isAuth);
                if (isAuth)
                {
                    writer.WriteInt32(dcId!.Value);
                    writer.WriteInt64(userId!.Value);
                    writer.WriteInt64(userAccessHash!.Value);
                }
            }
        }

        public void Dispose()
        {
            _asyncSignaler.Dispose();
        }
    }
}