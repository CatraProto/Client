using CatraProto.Client.TL.Schemas.CloudChats;
using System;
using System.Net;

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

        public ConnectionInfo(IPAddress ipAddress, int port, int dcId) : this(ConnectionProtocol.TcpAbridged, ipAddress, false, port, dcId, false, false, null, false, false)
        {

        }

        internal ConnectionInfo(ConnectionProtocol connectionProtocol, IPAddress ipAddress, bool ipv6, int port, int dcId, bool mediaOnly, bool tcpoOnly, byte[]? secret, bool cdn, bool isStatic)
        {
            ConnectionProtocol = connectionProtocol;
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Port = port;
            DcId = dcId;
            MediaOnly = mediaOnly;
            TcpoOnly = tcpoOnly;
            Secret = secret;
            Cdn = Cdn;
            Static = isStatic;
            Ipv6 = ipv6;
        }

        internal static ConnectionInfo FromDcOption(DcOptionBase dcOption)
        {
            return new ConnectionInfo(ConnectionProtocol.TcpAbridged, IPAddress.Parse(dcOption.IpAddress), dcOption.Ipv6, dcOption.Port, dcOption.Id, dcOption.MediaOnly, dcOption.TcpoOnly, dcOption.Secret, dcOption.Cdn, dcOption.Static);
        }

        public override string ToString()
        {
            return $"DC{DcId} ({IpAddress}:{Port}, Main: {Main})";
        }
    }
}