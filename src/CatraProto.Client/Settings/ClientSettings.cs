using System;

namespace CatraProto.Client.Settings
{
    public class ClientSettings
    {
        public string DatacenterAddress { get; set; } = "149.154.167.92";
        public ApiSettings ApiSettings { get; init; }
        public string SessionName { get; init; }
        public string SessionPath { get; init; }
        public ClientSettings(ApiSettings apiSettings, string sessionName, string? sessionPath = null)
        {
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