using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockAudio : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        public static int StaticConstructorId
        {
            get => -2143067670;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("audio_id")]
        public long AudioId { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


    #nullable enable
        public PageBlockAudio(long audioId, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            AudioId = audioId;
            Caption = caption;
        }
    #nullable disable
        internal PageBlockAudio()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(AudioId);
            writer.Write(Caption);
        }

        public override void Deserialize(Reader reader)
        {
            AudioId = reader.Read<long>();
            Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
        }

        public override string ToString()
        {
            return "pageBlockAudio";
        }
    }
}