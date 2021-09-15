using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryPeers : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase
	{


        public static int StaticConstructorId { get => -75283823; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("category")]
		public override CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("peers")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Category);
			writer.Write(Count);
			writer.Write(Peers);

		}

		public override void Deserialize(Reader reader)
		{
			Category = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
			Count = reader.Read<int>();
			Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase>();

		}
				
		public override string ToString()
		{
		    return "topPeerCategoryPeers";
		}
	}
}