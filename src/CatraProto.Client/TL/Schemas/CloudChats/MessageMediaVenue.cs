using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaVenue : MessageMediaBase
	{


        public static int StaticConstructorId { get => 784356159; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo")]
		public GeoPointBase Geo { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("address")]
		public string Address { get; set; }

[JsonPropertyName("provider")]
		public string Provider { get; set; }

[JsonPropertyName("venue_id")]
		public string VenueId { get; set; }

[JsonPropertyName("venue_type")]
		public string VenueType { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Geo);
			writer.Write(Title);
			writer.Write(Address);
			writer.Write(Provider);
			writer.Write(VenueId);
			writer.Write(VenueType);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<GeoPointBase>();
			Title = reader.Read<string>();
			Address = reader.Read<string>();
			Provider = reader.Read<string>();
			VenueId = reader.Read<string>();
			VenueType = reader.Read<string>();
		}

		public override string ToString()
		{
			return "messageMediaVenue";
		}
	}
}