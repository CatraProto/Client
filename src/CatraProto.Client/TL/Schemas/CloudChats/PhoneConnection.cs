using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneConnection : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
	{


        public static int StaticConstructorId { get => -1655957568; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public sealed override string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("ipv6")]
		public sealed override string Ipv6 { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public sealed override int Port { get; set; }

[Newtonsoft.Json.JsonProperty("peer_tag")]
		public byte[] PeerTag { get; set; }


        #nullable enable
 public PhoneConnection (long id,string ip,string ipv6,int port,byte[] peerTag)
{
 Id = id;
Ip = ip;
Ipv6 = ipv6;
Port = port;
PeerTag = peerTag;
 
}
#nullable disable
        internal PhoneConnection() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Ip);
			writer.Write(Ipv6);
			writer.Write(Port);
			writer.Write(PeerTag);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Ip = reader.Read<string>();
			Ipv6 = reader.Read<string>();
			Port = reader.Read<int>();
			PeerTag = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "phoneConnection";
		}
	}
}