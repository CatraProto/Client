using CatraProto.Client.MTProto.Auth.AuthKeyHandler;

namespace CatraProto.Client.MTProto.Auth
{
    class SaltHandler
    {
        private long _currentServerSalt;
        private object _mutex = new object();
        public SaltHandler(Api api, TemporaryAuthKey temporaryAuthKey)
        {
            if (temporaryAuthKey != null)
            {
                temporaryAuthKey.OnAuthKeyChanged += OnAuthKeyChanged;
            }
        }

        public long GetSalt()
        {
            lock (_mutex)
            {
                return _currentServerSalt;
            }
        }

        public void SetSalt(long salt)
        {
            lock (_mutex)
            {
                _currentServerSalt = salt;
            }
        }

        private void OnAuthKeyChanged(AuthKey authKey)
        {
            lock (_mutex)
            {
                _currentServerSalt = authKey.ServerSalt;
            }
        }
    }
}