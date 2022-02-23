using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterPhotos : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {
        public static int StaticConstructorId
        {
            get => -1777752804;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputMessagesFilterPhotos()
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
            return "inputMessagesFilterPhotos";
        }
    }
}