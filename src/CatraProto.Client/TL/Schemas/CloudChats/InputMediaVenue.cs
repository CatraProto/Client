using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        public static int StaticConstructorId
        {
            get => -1052959727;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("provider")]
        public string Provider { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_id")]
        public string VenueId { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_type")]
        public string VenueType { get; set; }


    #nullable enable
        public InputMediaVenue(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string title, string address, string provider, string venueId, string venueType)
        {
            GeoPoint = geoPoint;
            Title = title;
            Address = address;
            Provider = provider;
            VenueId = venueId;
            VenueType = venueType;
        }
    #nullable disable
        internal InputMediaVenue()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(GeoPoint);
            writer.Write(Title);
            writer.Write(Address);
            writer.Write(Provider);
            writer.Write(VenueId);
            writer.Write(VenueType);
        }

        public override void Deserialize(Reader reader)
        {
            GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            Title = reader.Read<string>();
            Address = reader.Read<string>();
            Provider = reader.Read<string>();
            VenueId = reader.Read<string>();
            VenueType = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputMediaVenue";
        }
    }
}