using System;
using System.IO;
using CatraProto.Client.MTProto.Session.Exceptions;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;
using CatraProto.TL.Exceptions;

namespace CatraProto.Client.MTProto.Session.Models
{
    class SessionData : SessionModel, IDisposable
    {
        private const int SupportedSessionVersion = 1;
        public Authorization Authorization { get; }
        public AuthorizationKeys AuthorizationKeys { get; }
        public UpdatesStates UpdatesStates { get; }
        private int _sessionVersion;

        public SessionData(object mutex) : base(mutex)
        {
            UpdatesStates = new UpdatesStates(Mutex);
            Authorization = new Authorization(Mutex);
            AuthorizationKeys = new AuthorizationKeys(Mutex);
        }

        private void EnsureVersion()
        {
            if (_sessionVersion > SupportedSessionVersion)
            {
                throw new SessionDeserializationException($"Deserialization failed: the session has been serialized by a newer version of CatraProto ({_sessionVersion} > {SupportedSessionVersion})");
            }
            else if (_sessionVersion < SupportedSessionVersion)
            {
                throw new SessionDeserializationException($"Deserialization failed: the session has been serialized by an older version of CatraProto ({_sessionVersion} < {SupportedSessionVersion})");
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _sessionVersion = reader.Read<int>();
                EnsureVersion();
                Authorization.Read(reader);
                AuthorizationKeys.Read(reader);
                UpdatesStates.Read(reader);
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.Write(1);
                Authorization.Save(writer);
                AuthorizationKeys.Save(writer);
                UpdatesStates.Save(writer);
            }
        }

        public void Dispose()
        {
            Authorization.Dispose();
        }
    }
}