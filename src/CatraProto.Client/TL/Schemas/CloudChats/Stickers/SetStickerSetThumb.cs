using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class SetStickerSetThumb : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1707717072;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Thumb { get; set; }


    #nullable enable
        public SetStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb)
        {
            Stickerset = stickerset;
            Thumb = thumb;
        }
    #nullable disable

        internal SetStickerSetThumb()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Stickerset);
            writer.Write(Thumb);
        }

        public void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
        }

        public override string ToString()
        {
            return "stickers.setStickerSetThumb";
        }
    }
}