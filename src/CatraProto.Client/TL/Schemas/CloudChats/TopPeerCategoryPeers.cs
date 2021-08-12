using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryPeers : TopPeerCategoryPeersBase
	{


        public static int StaticConstructorId { get => -75283823; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("category")]
		public override TopPeerCategoryBase Category { get; set; }

[JsonPropertyName("count")]
		public override int Count { get; set; }

[JsonPropertyName("peers")]
		public override IList<TopPeerBase> Peers { get; set; }

        
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
			Category = reader.Read<TopPeerCategoryBase>();
			Count = reader.Read<int>();
			Peers = reader.ReadVector<TopPeerBase>();
		}

		public override string ToString()
		{
			return "topPeerCategoryPeers";
		}
	}
}