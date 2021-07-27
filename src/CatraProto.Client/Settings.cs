using System;

namespace CatraProto.Client
{
    public class Settings
    {
        public string DatacenterAddress { get; set; } = "149.154.167.51";
        public string SessionName { get; init; }
        public string SessionPath { get; init; }
        public Settings(string sessionName, string sessionPath = null)
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