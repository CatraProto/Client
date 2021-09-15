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
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public override string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("ipv6")]
		public override string Ipv6 { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public override int Port { get; set; }

[Newtonsoft.Json.JsonProperty("peer_tag")]
		public byte[] PeerTag { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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