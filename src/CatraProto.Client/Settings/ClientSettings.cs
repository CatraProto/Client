using System;

namespace CatraProto.Client.Settings
{
    public class ClientSettings
    {
        public string DatacenterAddress { get; set; } = "149.154.167.51";
        public ApiSettings ApiSettings { get; init; }
        public string SessionName { get; init; }
        public string SessionPath { get; init; }
        public ClientSettings(string sessionName, string sessionPath = null)
        {
            SessionName = sessionName ?? throw new ArgumentNullException(nameof(sessionName));
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