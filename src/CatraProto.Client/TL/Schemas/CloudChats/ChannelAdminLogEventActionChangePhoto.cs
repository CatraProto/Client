using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionChangePhoto : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => 1129042607;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("prev_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PrevPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("new_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase NewPhoto { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionChangePhoto(CatraProto.Client.TL.Schemas.CloudChats.PhotoBase prevPhoto, CatraProto.Client.TL.Schemas.CloudChats.PhotoBase newPhoto)
        {
            PrevPhoto = prevPhoto;
            NewPhoto = newPhoto;
        }
    #nullable disable
        internal ChannelAdminLogEventActionChangePhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PrevPhoto);
            writer.Write(NewPhoto);
        }

        public override void Deserialize(Reader reader)
        {
            PrevPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            NewPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionChangePhoto";
        }
    }
}