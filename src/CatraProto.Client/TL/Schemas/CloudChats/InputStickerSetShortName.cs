using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickerSetShortName : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {
        public static int StaticConstructorId
        {
            get => -2044933984;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


    #nullable enable
        public InputStickerSetShortName(string shortName)
        {
            ShortName = shortName;
        }
    #nullable disable
        internal InputStickerSetShortName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ShortName);
        }

        public override void Deserialize(Reader reader)
        {
            ShortName = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputStickerSetShortName";
        }
    }
}