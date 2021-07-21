using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryPeers : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase
	{


        public static int StaticConstructorId { get => -75283823; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("category")]
		public override CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

[JsonPropertyName("count")]
		public override int Count { get; set; }

[JsonPropertyName("peers")]
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
	}
}