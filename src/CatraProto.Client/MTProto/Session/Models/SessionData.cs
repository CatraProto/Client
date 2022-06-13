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
using CatraProto.Client.MTProto.Session.Exceptions;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal enum SessionVersion
    {
        BaseVersion = 1,
        NewAuthorization,
    }

    internal class SessionData : SessionModel, IDisposable
    {
        private const int CurrentSessionVersion = 2;
        public Authorization Authorization { get; }
        public AuthorizationKeys AuthorizationKeys { get; }
        public UpdatesStates UpdatesStates { get; }
        public RandomId RandomId { get; }
        private SessionVersion _sessionVersion;

        public SessionData(object mutex) : base(mutex)
        {
            UpdatesStates = new UpdatesStates(Mutex);
            Authorization = new Authorization(Mutex);
            AuthorizationKeys = new AuthorizationKeys(Mutex);
            RandomId = new RandomId(mutex);
        }

        private void EnsureVersion()
        {
            if ((int)_sessionVersion > CurrentSessionVersion)
            {
                throw new SessionDeserializationException($"Deserialization failed: the session has been serialized by a newer version of CatraProto ({_sessionVersion} > {CurrentSessionVersion})");
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _sessionVersion = (SessionVersion)reader.ReadInt32().Value;
                EnsureVersion();
                Authorization.Read(reader, _sessionVersion);
                AuthorizationKeys.Read(reader);
                UpdatesStates.Read(reader);
                RandomId.Read(reader);
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.WriteInt32(CurrentSessionVersion);
                Authorization.Save(writer);
                AuthorizationKeys.Save(writer);
                UpdatesStates.Save(writer);
                RandomId.Save(writer);
            }
        }

        public void Dispose()
        {
            Authorization.Dispose();
        }
    }
}