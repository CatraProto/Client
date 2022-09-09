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

namespace CatraProto.Client.MTProto.Auth
{
    public class SessionIdHandler
    {
        private readonly object _mutex = new object();
        private long _sessionId;
        private long _uniqueId;

        public long GetSessionId(out long uniqueId)
        {
            lock (_mutex)
            {
                uniqueId = _uniqueId;
                return _sessionId;
            }
        }

        public void SetSessionId(long newSessionId, long uniqueId)
        {
            lock (_mutex)
            {
                _uniqueId = uniqueId;
                _sessionId = newSessionId;
            }
        }

        public bool UpdateIfDifferent(long receivedUniqueId, long receivedSessionId)
        {
            lock (_mutex)
            {
                if (_uniqueId == receivedUniqueId)
                {
                    return false;
                }

                _uniqueId = receivedUniqueId;
                _sessionId = receivedSessionId;
                return true;
            }
        }
    }
}