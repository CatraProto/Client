using CatraProto.Client.MTProto.Session.Interfaces;

namespace CatraProto.Client.MTProto.Settings
{
    public class SessionSettings
    {
        public string SessionName { get; }
        internal IAsyncSessionSerializer SessionSerializer { get; }
        public SessionSettings(IAsyncSessionSerializer sessionSerializer, string sessionName)
        {
            SessionSerializer = sessionSerializer;
            SessionName = sessionName;
        }
    }
}