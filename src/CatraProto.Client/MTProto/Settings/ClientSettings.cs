using System;

namespace CatraProto.Client.MTProto.Settings
{
    public class ClientSettings
    {
        public ConnectionSettings ConnectionSettings { get; }
        public ApiSettings ApiSettings { get; init; }
        public string SessionName { get; init; }
        public string SessionPath { get; init; }

        public ClientSettings(ApiSettings apiSettings, string? sessionName, ConnectionSettings? connectionSetting = null, string? sessionPath = null)
        {
            ConnectionSettings = connectionSetting ?? new ConnectionSettings();
            
            SessionName = sessionName ?? throw new ArgumentNullException(nameof(sessionName));
            ApiSettings = apiSettings;
            if (sessionPath == null)
            {
                SessionPath = sessionName + ".catra";
            }
            else
            {
                SessionPath = sessionPath;
            }
        }
    }
}