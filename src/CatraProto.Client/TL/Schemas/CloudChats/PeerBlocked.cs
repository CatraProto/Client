using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase
	{


        public static int StaticConstructorId { get => -386039788; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer_id")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PeerId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "peerBlocked";
		}
	}
}