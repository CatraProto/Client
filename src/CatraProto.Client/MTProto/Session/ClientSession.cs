using System.IO;
using CatraProto.Client.Settings;
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

        public ClientSession(ClientSettings settings, ILogger logger)
        {
            Settings = settings;
            Logger = logger.ForContext<ClientSession>().ForContext("Session", Name);
        }

        public FileStream GetSessionStream()
        {
            return File.Open(Settings.SessionPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
    }
}