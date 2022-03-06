using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CatraProto.Client.TL.Schemas.CloudChats;
using Microsoft.Data.Sqlite;
using Serilog;

namespace CatraProto.Client.Database
{
    class DatabaseManager : IDisposable
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
            PeerDatabase = new PeerDatabase(_sqliteConnection, settings.PeerCacheSize, _mutex, logger);
            InternalDatabase = new InternalDatabase(_sqliteConnection, _mutex, logger);
        }

        public void InitDb()
        {
            lock (_mutex)
            {
                _logger.Information("Initializing database and defining structures...");
                _sqliteConnection.Open();
                InternalDatabase.DefineStructures();
                PeerDatabase.DefineStructures();
                _logger.Information("Database initialized");
            }
        }

        public void AsTransaction(Action<DatabaseManager, SqliteTransaction> action, IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            lock (_mutex)
            {
                var transaction = _sqliteConnection.BeginTransaction(isolationLevel);
                action(this, transaction);
                transaction.Dispose();
            }
        }

        public void UpdateChats(IList<ChatBase>? chats = null, IList<UserBase>? users = null)
        {
            AsTransaction((manager, transaction) =>
            {
                if (chats is not null)
                {
                    foreach (var chat in chats)
                    {
                        manager.PeerDatabase.UpdateChat(chat, transaction);
                        if (chat is Channel or ChannelForbidden)
                        {
                            if (Updates.UpdatesTools.IsInChat(chat))
                            {
                                _client.UpdatesReceiver.CreateProcessor(chat.Id, true);
                            }
                            else
                            {
                                _client.UpdatesReceiver.CloseProcessor(chat.Id);
                            }
                        }
                    }
                }

                if (users is not null)
                {
                    foreach (var user in users)
                    {
                        if (user is User userFull)
                        {
                            if (userFull.AccessHash is not null)
                            {
                                manager.PeerDatabase.UpdateChat(user, transaction);
                            }
                        }
                    }
                }

                transaction.Commit();
            });
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