using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.MTProto.Session
{
    public class ClientSession
    {
        public string Name
        {
            get => Settings.SessionName;
        }

        public ILogger Logger { get; }
        public ClientSettings Settings { get; }
        public SessionManager SessionManager { get; }

        public ClientSession(ClientSettings settings, ILogger logger)
        {
            Settings = settings;
            SessionManager = new SessionManager();
            Logger = logger.ForContext<ClientSession>().ForContext("Session", Name);
        }
    }
}