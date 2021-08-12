using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelLocation : ChannelLocationBase
	{


        public static int StaticConstructorId { get => 547062491; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo_point")]
		public GeoPointBase GeoPoint { get; set; }

[JsonPropertyName("address")]
		public string Address { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);
			writer.Write(Address);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<GeoPointBase>();
			Address = reader.Read<string>();
		}

		public override string ToString()
		{
			return "channelLocation";
		}
	}
}