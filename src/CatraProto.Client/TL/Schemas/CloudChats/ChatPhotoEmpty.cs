using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatPhotoEmpty : CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase
    {
        public static int StaticConstructorId
        {
            get => 935395612;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public ChatPhotoEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "chatPhotoEmpty";
        }
    }
}