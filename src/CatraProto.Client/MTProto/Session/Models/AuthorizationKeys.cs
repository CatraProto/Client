using System.Collections.Generic;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class AuthorizationKeys : ISessionSerializer
    {
        private readonly Dictionary<int, AuthKeyData> _authKeys = new Dictionary<int, AuthKeyData>();
        private readonly object _mutex;

        public AuthorizationKeys(object mutex)
        {
            _mutex = mutex;
        }

        public AuthKeyData GetAuthKey(int dc, out bool justCreated)
        {
            lock (_mutex)
            {
                AuthKeyData authKey;
                if (_authKeys.TryGetValue(dc, out var outKey))
                {
                    authKey = outKey;
                    justCreated = false;
                }
                else
                {
                    authKey = new AuthKeyData(_mutex);
                    justCreated = true;
                    _authKeys.TryAdd(dc, authKey);
                }

                return authKey;
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                var count = reader.Read<int>();
                for (int i = 0; i < count; i++)
                {
                    var dc = reader.Read<int>();
                    var key = new AuthKeyData(_mutex);
                    key.Read(reader);
                    _authKeys.TryAdd(dc, key);
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                writer.Write(_authKeys.Count);
                foreach (var (dc, key) in _authKeys)
                {
                    writer.Write(dc);
                    writer.Write(key);
                }
            }
        }
    }
}