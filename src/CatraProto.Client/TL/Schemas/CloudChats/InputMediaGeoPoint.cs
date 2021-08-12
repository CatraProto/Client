using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGeoPoint : InputMediaBase
	{


        public static int StaticConstructorId { get => -104578748; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo_point")]
		public InputGeoPointBase GeoPoint { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<InputGeoPointBase>();
		}

		public override string ToString()
		{
			return "inputMediaGeoPoint";
		}
	}
}