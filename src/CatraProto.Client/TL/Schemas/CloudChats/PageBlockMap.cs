using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockMap : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        public static int StaticConstructorId
        {
            get => -1538310410;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public int Zoom { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


    #nullable enable
        public PageBlockMap(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo, int zoom, int w, int h, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Geo = geo;
            Zoom = zoom;
            W = w;
            H = h;
            Caption = caption;
        }
    #nullable disable
        internal PageBlockMap()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Geo);
            writer.Write(Zoom);
            writer.Write(W);
            writer.Write(H);
            writer.Write(Caption);
        }

        public override void Deserialize(Reader reader)
        {
            Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            Zoom = reader.Read<int>();
            W = reader.Read<int>();
            H = reader.Read<int>();
            Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
        }

        public override string ToString()
        {
            return "pageBlockMap";
        }
    }
}