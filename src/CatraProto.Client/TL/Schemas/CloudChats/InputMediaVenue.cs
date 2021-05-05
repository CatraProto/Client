using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaVenue : InputMediaBase
    {
        public static int ConstructorId { get; } = -1052959727;
        public InputGeoPointBase GeoPoint { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Provider { get; set; }
        public string VenueId { get; set; }
        public string VenueType { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(GeoPoint);
            writer.Write(Title);
            writer.Write(Address);
            writer.Write(Provider);
            writer.Write(VenueId);
            writer.Write(VenueType);
        }

        public override void Deserialize(Reader reader)
        {
            GeoPoint = reader.Read<InputGeoPointBase>();
            Title = reader.Read<string>();
            Address = reader.Read<string>();
            Provider = reader.Read<string>();
            VenueId = reader.Read<string>();
            VenueType = reader.Read<string>();
        }
    }
}