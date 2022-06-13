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
using CatraProto.Client.ApiManagers;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class Authorization : SessionModel, IDisposable
    {
        private readonly AsyncSignaler _asyncSignaler = new AsyncSignaler(false);
        private LoginState _loginState = LoginState.AwaitingLogin;
        private long? _userId;
        private int? _dcId;

        public Authorization(object mutex) : base(mutex)
        {
        }

        public void SetAuthorized(LoginState authorized, int? dcId, long? userId)
        {
            lock (Mutex)
            {
                _loginState = authorized;
                _userId = userId;
                _dcId = dcId;
                _asyncSignaler.SetSignal(authorized == LoginState.LoggedIn);
            }
        }

        public LoginState GetAuthorization(out int? dcId, out long? userId)
        {
            lock (Mutex)
            {
                dcId = _dcId;
                userId = _userId;
                return _loginState;
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

        public void Read(Reader reader, SessionVersion version)
        {
            lock (Mutex)
            {
                if (version is SessionVersion.BaseVersion)
                {
                    var isAuthorized = reader.ReadBool().Value;
                    _asyncSignaler.SetSignal(isAuthorized);
                    if (isAuthorized)
                    {
                        _dcId = reader.ReadInt32().Value;
                        _userId = reader.ReadInt64().Value;
                        _loginState = LoginState.LoggedIn;
                        //access_hash
                        reader.ReadInt64();
                    }
                }
                else if (version is SessionVersion.NewAuthorization)
                {
                    _loginState = (LoginState)reader.ReadInt32().Value;
                    if (_loginState is LoginState.LoggedIn)
                    {
                        _userId = reader.ReadInt64().Value;
                        _dcId = reader.ReadInt32().Value;
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Invalid version {version}");
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.WriteInt32((int)_loginState);
                if (_loginState is LoginState.LoggedIn)
                {
                    writer.WriteInt64(_userId!.Value);
                    writer.WriteInt32(_dcId!.Value);
                }
            }
        }

        public void Dispose()
        {
            _asyncSignaler.Dispose();
        }
    }
}