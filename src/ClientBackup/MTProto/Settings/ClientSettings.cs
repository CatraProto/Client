namespace CatraProto.Client.MTProto.Settings
{
    public class ClientSettings
    {
        public ConnectionSettings ConnectionSettings { get; }
        public SessionSettings SessionSettings { get; }
        public ApiSettings ApiSettings { get; }

        public ClientSettings(SessionSettings sessionSettings, ApiSettings apiSettings, ConnectionSettings connectionSetting)
        {
            ConnectionSettings = connectionSetting;
            SessionSettings = sessionSettings;
            ApiSettings = apiSettings;
        }
    }
}