using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockSlideshow : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        public static int StaticConstructorId
        {
            get => 52401552;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("items")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Items { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


    #nullable enable
        public PageBlockSlideshow(IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> items, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Items = items;
            Caption = caption;
        }
    #nullable disable
        internal PageBlockSlideshow()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Items);
            writer.Write(Caption);
        }

        public override void Deserialize(Reader reader)
        {
            Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
            Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
        }

        public override string ToString()
        {
            return "pageBlockSlideshow";
        }
    }
}