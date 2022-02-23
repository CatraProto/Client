using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatEditPhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => 2144015272;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }


    #nullable enable
        public MessageActionChatEditPhoto(CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photo)
        {
            Photo = photo;
        }
    #nullable disable
        internal MessageActionChatEditPhoto()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Photo);
        }

        public override void Deserialize(Reader reader)
        {
            Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
        }

        public override string ToString()
        {
            return "messageActionChatEditPhoto";
        }
    }
}