using System.Collections.Generic;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class AuthorizationKeys : SessionModel
    {
        private readonly Dictionary<int, (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey)> _authKeys = new Dictionary<int, (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey)>();


        public AuthorizationKeys(object mutex) : base(mutex)
        {
        }

        public (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey) GetAuthKeys(int dc, out bool justCreated)
        {
            lock (Mutex)
            {
                (AuthKeyCache PermanentAuthKey, AuthKeyCache TemporaryAuthKey) authKey;
                if (_authKeys.TryGetValue(dc, out var outKey))
                {
                    authKey = outKey;
                    justCreated = false;
                }
                else
                {
                    var permKey = new AuthKeyCache(Mutex);
                    var tempKey = new AuthKeyCache(Mutex);
                    if (OnUpdated is not null)
                    {
                        permKey.RegisterOnUpdated(OnUpdated);
                        tempKey.RegisterOnUpdated(OnUpdated);
                    }

                    authKey.PermanentAuthKey = permKey;
                    authKey.TemporaryAuthKey = tempKey;
                    justCreated = true;
                    _authKeys.TryAdd(dc, authKey);
                }

                return authKey;
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                var count = reader.Read<int>();
                for (var i = 0; i < count; i++)
                {
                    var dc = reader.Read<int>();
                    var permKey = new AuthKeyCache(Mutex);
                    var tempKey = new AuthKeyCache(Mutex);
                    permKey.Read(reader);
                    tempKey.Read(reader);
                    _authKeys.TryAdd(dc, (permKey, tempKey));
                    if (OnUpdated is not null)
                    {
                        permKey.RegisterOnUpdated(OnUpdated);
                        tempKey.RegisterOnUpdated(OnUpdated);
                    }
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.Write(_authKeys.Count);
                foreach (var (dc, key) in _authKeys)
                {
                    writer.Write(dc);
                    key.PermanentAuthKey.Save(writer);
                    key.TemporaryAuthKey.Save(writer);
                }
            }
        }
    }
}