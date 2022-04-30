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

using CatraProto.Client.Connections;

namespace CatraProto.Client.MTProto.Settings
{
    public class ConnectionSettings
    {
        public ConnectionInfo DefaultDatacenter { get; }
        public int PfsKeyDuration { get; }
        public int ConnectionTimeout { get; }
        public int ConnectionRetry { get; }
        public bool Ipv6Allowed { get; }
        public bool Ipv6Only { get; }

        public ConnectionSettings(ConnectionInfo defaultDatacenter, int pfsKeyDuration = 1500, int connectionTimeout = 60, int connectionRetry = 10, bool ipv6Allowed = false, bool ipv6Only = false)
        {
            DefaultDatacenter = defaultDatacenter;
            ConnectionRetry = connectionRetry;
            PfsKeyDuration = pfsKeyDuration;
            ConnectionTimeout = connectionTimeout;
            Ipv6Allowed = ipv6Allowed;
            Ipv6Only = ipv6Only;
        }
    }
}