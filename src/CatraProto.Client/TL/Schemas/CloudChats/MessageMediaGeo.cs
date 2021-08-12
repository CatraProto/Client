using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGeo : MessageMediaBase
	{


        public static int StaticConstructorId { get => 1457575028; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo")]
		public GeoPointBase Geo { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Geo);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<GeoPointBase>();
		}

		public override string ToString()
		{
			return "messageMediaGeo";
		}
	}
}