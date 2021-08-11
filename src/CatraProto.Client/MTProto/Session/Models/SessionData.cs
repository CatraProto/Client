using System;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class SessionData : ISessionSerializer
    {
        private const int SupportedSessionVersion = 1;
        public Authorization Authorization { get; }
        public AuthorizationKeys AuthorizationKeys { get; }
        private readonly object _mutex = new object();
        private int _sessionVersion;

        public SessionData()
        {
            Authorization = new Authorization(_mutex);
            AuthorizationKeys = new AuthorizationKeys(_mutex);
        }

        private void EnsureVersion()
        {
            if (_sessionVersion > SupportedSessionVersion)
            {
                throw new Exception($"Deserialization failed, the sessions has been serialized by a newer version of CatraProto ({_sessionVersion} > {SupportedSessionVersion})");
            }
            else if (_sessionVersion < SupportedSessionVersion)
            {
                throw new Exception($"Deserialization failed, the sessions has been serialized by an older version of CatraProto ({_sessionVersion} < {SupportedSessionVersion})");
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _sessionVersion = reader.Read<int>();
                EnsureVersion();
                Authorization.Read(reader);
                AuthorizationKeys.Read(reader);
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                writer.Write(_sessionVersion);
                Authorization.Save(writer);
                AuthorizationKeys.Save(writer);
            }
        }
    }
}