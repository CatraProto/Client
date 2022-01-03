using System;
using System.IO;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.Updates;
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
        internal UpdatesHandler? UpdatesHandler { get; set; }
        
        public ClientSession(ClientSettings settings, ILogger logger)
        {
            Settings = settings;
            SessionManager = new SessionManager();
            Logger = logger.ForContext<ClientSession>().ForContext("Session", Name);
            ConnectionPool = new ConnectionPool(this, Logger);
        }

        public async Task ReadSessionAsync()
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            var sessionData = await sessionSerializer.ReadAsync(Logger.ForContext(sessionSerializer.GetType()));
            SessionManager.Read(sessionData);
        }

        public Task SaveSessionAsync()
        {
            var sessionSerializer = Settings.SessionSettings.SessionSerializer;
            return sessionSerializer.SaveAsync(SessionManager.Save(), Logger.ForContext(sessionSerializer.GetType()));
        }

        public async ValueTask DisposeAsync()
        {
            await ConnectionPool.DisposeAsync();
            SessionManager.Dispose();
            Settings.SessionSettings.SessionSerializer.Dispose();
        }
    }
}