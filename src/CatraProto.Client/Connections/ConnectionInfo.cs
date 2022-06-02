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
using System.Net;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Connections
{
    public class ConnectionInfo
    {
        public ConnectionProtocol ConnectionProtocol { get; }
        public IPAddress IpAddress { get; }
        public int Port { get; }
        public int DcId { get; }
        public bool Main { get; set; }
        public bool MediaOnly { get; }
        public bool TcpoOnly { get; }
        public byte[]? Secret { get; }
        public bool Cdn { get; }
        public bool Static { get; }
        public bool Ipv6 { get; }
        public bool Test { get; }

        public ConnectionInfo(IPAddress ipAddress, int port, int dcId, bool test) : this(ConnectionProtocol.TcpAbridged, ipAddress, test, false, port, dcId, false, false, null, false, false)
        {

        }

        internal ConnectionInfo(ConnectionProtocol connectionProtocol, IPAddress ipAddress, bool test, bool ipv6, int port, int dcId, bool mediaOnly, bool tcpoOnly, byte[]? secret, bool cdn, bool isStatic)
        {
            ConnectionProtocol = connectionProtocol;
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Port = port;
            DcId = dcId;
            MediaOnly = mediaOnly;
            TcpoOnly = tcpoOnly;
            Secret = secret;
            Cdn = cdn;
            Static = isStatic;
            Ipv6 = ipv6;
            Test = test;
        }

        internal static ConnectionInfo FromDcOption(DcOptionBase dcOption, bool isTest)
        {
            return new ConnectionInfo(ConnectionProtocol.TcpAbridged, IPAddress.Parse(dcOption.IpAddress), isTest, dcOption.Ipv6, dcOption.Port, dcOption.Id, dcOption.MediaOnly, dcOption.TcpoOnly, dcOption.Secret, dcOption.Cdn, dcOption.Static);
        }

        public override string ToString()
        {
            return $"DC{DcId} ({IpAddress}:{Port}, Main: {Main})";
        }
    }
}