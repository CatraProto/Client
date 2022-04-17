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
            Directory.CreateDirectory(settings.Path);
            _sqliteConnection = new SqliteConnection($"Data Source={settings.Path}{client.ClientSession.Name}.db");
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
            using var transaction = _sqliteConnection.BeginTransaction(System.Data.IsolationLevel.Serializable);
            if (chats is not null)
            {
                foreach (var chat in chats)
                {
                    if (chat is Channel or ChannelForbidden)
                    {
                        PeerDatabase.UpdateChannel(chat, transaction);
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
                        PeerDatabase.UpdateChat(chat, transaction);
                    }
                }
            }

            if (users is not null)
            {
                foreach (var user in users)
                {
                    PeerDatabase.UpdateUser(user, transaction);
                }
            }

            transaction.Commit();

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