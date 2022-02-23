using System;
using System.IO;
using CatraProto.Client.MTProto.Session.Exceptions;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session
{
    public class SessionManager : IDisposable
    {
        internal SessionData SessionData { get; }
        private readonly object _mutex = new object();
        private bool _hasRead;

        public SessionManager()
        {
            SessionData = new SessionData(_mutex);
        }

        public byte[] Save()
        {
            using (var writer = new Writer(MergedProvider.Singleton, new MemoryStream()))
            {
                SessionData.Save(writer);
                return ((MemoryStream)writer.Stream).ToArray();
            }
        }

        public void Read(byte[] serializedData)
        {
            lock (_mutex)
            {
                if (serializedData.Length > 0)
                {
                    using (var reader = new Reader(MergedProvider.Singleton, new MemoryStream(serializedData)))
                    {
                        try
                        {
                            SessionData.Read(reader);
                        }
                        catch (IOException)
                        {
                            throw new SessionDeserializationException("Session corrupted");
                        }
                    }
                }

                _hasRead = true;
            }
        }

        internal bool GetHasRead()
        {
            lock (_mutex)
            {
                return _hasRead;
            }
        }

        internal void ThrowIfNotRead()
        {
            lock (_mutex)
            {
                if (!_hasRead)
                {
                    throw new Exception("Please deserialize the session first");
                }
            }
        }

        public void Dispose()
        {
            lock (_mutex)
            {
                SessionData.Dispose();
            }
        }
    }
}