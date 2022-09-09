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
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.MTProto.Session
{
    internal class ClientSession : IAsyncDisposable
    {
        public string Name
        {
            get => Settings.SessionSettings.SessionName;
        }

        public ILogger Logger { get; }
        public ClientSettings Settings { get; }
        public SessionManager SessionManager { get; }
        internal ConnectionPool ConnectionPool { get; }

        public ClientSession(TelegramClient client, ClientSettings settings, ILogger logger)
        {
            Settings = settings;
            SessionManager = new SessionManager(logger);
            Logger = logger.ForContext<ClientSession>().ForContext("Session", Name);
            ConnectionPool = new ConnectionPool(client, Logger);
        }

        public async Task<bool> ReadSessionAsync(CancellationToken token = default)
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            var sessionData = await sessionSerializer.ReadAsync(Logger.ForContext(sessionSerializer.GetType()), token);
            return SessionManager.Read(sessionData);
        }

        public Task SaveSessionAsync(CancellationToken token)
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            return sessionSerializer.SaveAsync(SessionManager.Save(), Logger.ForContext(sessionSerializer.GetType()), token);
        }

        public async ValueTask DisposeAsync()
        {
            SessionManager.Dispose();
            Settings.SessionSettings.SessionSerializer.Dispose();
            await ConnectionPool.DisposeAsync();
        }
    }
}