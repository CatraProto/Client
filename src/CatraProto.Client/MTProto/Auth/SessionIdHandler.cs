namespace CatraProto.Client.MTProto.Auth
{
    public class SessionIdHandler
    {
        public object _mutex = new object();
        private long _sessionId;
        
        public long GetSessionId()
        {
            lock (_mutex)
            {
                return _sessionId;
            }
        }
        
        public void SetSessionId(long newSessionId)
        {
            lock (_mutex)
            {
                _sessionId = newSessionId;
            }
        }
    }
}