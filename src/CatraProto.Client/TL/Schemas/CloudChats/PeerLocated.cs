using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
	{


        public static int StaticConstructorId { get => -901375139; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("expires")]
		public override int Expires { get; set; }

[Newtonsoft.Json.JsonProperty("distance")]
		public int Distance { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Expires);
			writer.Write(Distance);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Expires = reader.Read<int>();
			Distance = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "peerLocated";
		}
	}
}