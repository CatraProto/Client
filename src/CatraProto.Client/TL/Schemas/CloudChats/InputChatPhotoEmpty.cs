using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputChatPhotoEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase
    {
        public static int StaticConstructorId
        {
            get => 480546647;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputChatPhotoEmpty()
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
            return "inputChatPhotoEmpty";
        }
    }
}