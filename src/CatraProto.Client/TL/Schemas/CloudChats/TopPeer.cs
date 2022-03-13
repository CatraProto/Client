using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeer : CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase
	{


        public static int StaticConstructorId { get => -305282981; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("rating")]
		public sealed override double Rating { get; set; }


        #nullable enable
 public TopPeer (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,double rating)
{
 Peer = peer;
Rating = rating;
 
}
#nullable disable
        internal TopPeer() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Rating);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Rating = reader.Read<double>();

		}
				
		public override string ToString()
		{
		    return "topPeer";
		}
	}
}