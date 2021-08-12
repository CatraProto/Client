using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionGeoProximityReached : MessageActionBase
	{


        public static int StaticConstructorId { get => -1730095465; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("from_id")]
		public PeerBase FromId { get; set; }

[JsonPropertyName("to_id")]
		public PeerBase ToId { get; set; }

[JsonPropertyName("distance")]
		public int Distance { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FromId);
			writer.Write(ToId);
			writer.Write(Distance);

		}

		public override void Deserialize(Reader reader)
		{
			FromId = reader.Read<PeerBase>();
			ToId = reader.Read<PeerBase>();
			Distance = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messageActionGeoProximityReached";
		}
	}
}