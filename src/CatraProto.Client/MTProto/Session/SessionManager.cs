/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.MTProto.Session
{
    public class SessionManager : IDisposable
    {
        internal SessionData SessionData { get; }
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        private bool _hasRead;

        public SessionManager(ILogger logger)
        {
            SessionData = new SessionData(_mutex);
            _logger = logger.ForContext<SessionManager>();
        }

        public byte[] Save()
        {
            using (var writer = new Writer(MergedProvider.Singleton, new MemoryStream()))
            {
                SessionData.Save(writer);
                return ((MemoryStream)writer.Stream).ToArray();
            }
        }

        public bool Read(byte[] serializedData)
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
                        catch (Exception e)
                        {
                            _logger.Error(e, "Failed to deserialize session");
                            return false;
                        }
                    }
                }

                _hasRead = true;
            }

            return true;
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