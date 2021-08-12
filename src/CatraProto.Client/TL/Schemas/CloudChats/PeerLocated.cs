using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerLocated : PeerLocatedBase
	{


        public static int StaticConstructorId { get => -901375139; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("expires")]
		public override int Expires { get; set; }

[JsonPropertyName("distance")]
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
			Peer = reader.Read<PeerBase>();
			Expires = reader.Read<int>();
			Distance = reader.Read<int>();
		}

		public override string ToString()
		{
			return "peerLocated";
		}
	}
}