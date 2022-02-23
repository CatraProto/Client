using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputWebFileGeoPointLocation : CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase
    {
        public static int StaticConstructorId
        {
            get => -1625153079;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public int Zoom { get; set; }

        [Newtonsoft.Json.JsonProperty("scale")]
        public int Scale { get; set; }


    #nullable enable
        public InputWebFileGeoPointLocation(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, long accessHash, int w, int h, int zoom, int scale)
        {
            GeoPoint = geoPoint;
            AccessHash = accessHash;
            W = w;
            H = h;
            Zoom = zoom;
            Scale = scale;
        }
    #nullable disable
        internal InputWebFileGeoPointLocation()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(GeoPoint);
            writer.Write(AccessHash);
            writer.Write(W);
            writer.Write(H);
            writer.Write(Zoom);
            writer.Write(Scale);
        }

        public override void Deserialize(Reader reader)
        {
            GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            AccessHash = reader.Read<long>();
            W = reader.Read<int>();
            H = reader.Read<int>();
            Zoom = reader.Read<int>();
            Scale = reader.Read<int>();
        }

        public override string ToString()
        {
            return "inputWebFileGeoPointLocation";
        }
    }
}