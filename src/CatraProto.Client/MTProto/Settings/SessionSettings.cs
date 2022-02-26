using CatraProto.Client.MTProto.Session.Interfaces;

namespace CatraProto.Client.MTProto.Settings
{
    public class SessionSettings
    {
        public string SessionName { get; }
        public DatabaseSettings DatabaseSettings { get; }
        internal IAsyncSessionSerializer SessionSerializer { get; }
        public SessionSettings(IAsyncSessionSerializer sessionSerializer, DatabaseSettings databaseSettings, string sessionName)
        {
            DatabaseSettings = databaseSettings;
            SessionSerializer = sessionSerializer;
            SessionName = sessionName;
        }
    }
}