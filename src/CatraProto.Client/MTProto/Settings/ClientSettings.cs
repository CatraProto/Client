namespace CatraProto.Client.MTProto.Settings
{
    public class ClientSettings
    {
        public DatabaseSettings DatabaseSettings { get; }
        public ConnectionSettings ConnectionSettings { get; }
        public SessionSettings SessionSettings { get; }
        public ApiSettings ApiSettings { get; }

        public ClientSettings(SessionSettings sessionSettings, ApiSettings apiSettings, ConnectionSettings connectionSetting, DatabaseSettings databaseSettings)
        {
            ConnectionSettings = connectionSetting;
            DatabaseSettings = databaseSettings;
            SessionSettings = sessionSettings;
            ApiSettings = apiSettings;
        }
    }
}