using Serilog;

namespace CatraProto.Client.MTProto
{
    public class Session
    {
        public string Name
        {
            get => Settings.SessionName;
        }

        public ILogger Logger { get; }
        public Settings Settings { get; }
        internal MessageIdsHandler MessageIdsHandler { get; }

        public Session(Settings settings, ILogger logger)
        {
            Settings = settings;
            Logger = logger.ForContext<Session>().ForContext("Session", Name);
            MessageIdsHandler = new MessageIdsHandler(logger);
        }
    }
}