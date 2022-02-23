using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterVoice : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {
        public static int StaticConstructorId
        {
            get => 1358283666;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputMessagesFilterVoice()
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
            return "inputMessagesFilterVoice";
        }
    }
}