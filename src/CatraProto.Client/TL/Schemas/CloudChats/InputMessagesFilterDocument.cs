using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterDocument : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {
        public static int StaticConstructorId
        {
            get => -1629621880;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputMessagesFilterDocument()
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
            return "inputMessagesFilterDocument";
        }
    }
}