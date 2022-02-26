using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.MTProto.Session
{
    class ClientSession : IAsyncDisposable
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
            SessionManager = new SessionManager();
            Logger = logger.ForContext<ClientSession>().ForContext("Session", Name);
            ConnectionPool = new ConnectionPool(client, Logger);
        }

        public async Task ReadSessionAsync(CancellationToken token = default)
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            var sessionData = await sessionSerializer.ReadAsync(Logger.ForContext(sessionSerializer.GetType()), token);
            SessionManager.Read(sessionData);
        }

        public Task SaveSessionAsync(CancellationToken token)
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            return sessionSerializer.SaveAsync(SessionManager.Save(), Logger.ForContext(sessionSerializer.GetType()), token);
        }

        public async ValueTask DisposeAsync()
        {
            await ConnectionPool.DisposeAsync();
            SessionManager.Dispose();
            Settings.SessionSettings.SessionSerializer.Dispose();
        }
    }
}