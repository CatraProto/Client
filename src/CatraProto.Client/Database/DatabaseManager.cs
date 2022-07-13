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
using System.Collections.Generic;
using System.IO;
using CatraProto.Client.TL.Schemas.CloudChats;
using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    internal class DatabaseManager : IDisposable
    {
        public PeerDatabase PeerDatabase { get; }
        public InternalDatabase InternalDatabase { get; }

        private readonly TelegramClient _client;
        private readonly SqliteConnection _sqliteConnection;
        private readonly object _mutex = new object();
        private readonly ILogger _logger;

        public DatabaseManager(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<DatabaseManager>();
            var settings = client.ClientSession.Settings.SessionSettings.DatabaseSettings;
            Directory.CreateDirectory(Path.GetDirectoryName(settings.Path) ?? "");
            _sqliteConnection = new SqliteConnection($"Data Source={settings.Path}");
            PeerDatabase = new PeerDatabase(client, _sqliteConnection, _mutex, logger);
            InternalDatabase = new InternalDatabase(_sqliteConnection, _mutex, logger);
        }

        public void InitDb()
        {
            lock (_mutex)
            {
                _logger.Information("Opening database connection and defining structures");
                _sqliteConnection.Open();
                InternalDatabase.DefineStructures();
                PeerDatabase.DefineStructures();
                _logger.Information("Database initialized");
            }
        }

        public void UpdateChats(IList<ChatBase>? chats = null, IList<UserBase>? users = null)
        {
            lock (_mutex)
            {
                using var transaction = _sqliteConnection.BeginTransaction(System.Data.IsolationLevel.Serializable);
                if (chats is not null)
                {
                    foreach (var chat in chats)
                    {
                        if (chat is Channel or ChannelForbidden)
                        {
                            PeerDatabase.UpdatePeerObject(chat, transaction);
                            if (Updates.UpdatesTools.IsInChat(chat))
                            {
                                _client.UpdatesReceiver.CreateProcessor(chat.Id, true);
                            }
                            else
                            {
                                _client.UpdatesReceiver.CloseProcessor(chat.Id);
                            }
                        }
                        else
                        {
                            PeerDatabase.UpdatePeerObject(chat, transaction);
                        }
                    }
                }

                if (users is not null)
                {
                    foreach (var user in users)
                    {
                        PeerDatabase.UpdatePeerObject(user, transaction);
                    }
                }

                transaction.Commit();
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                _sqliteConnection.Dispose();
            }
        }
    }
}