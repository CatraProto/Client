using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterMyMentions : CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase
    {
        public static int StaticConstructorId
        {
            get => -1040652646;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputMessagesFilterMyMentions()
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
            return "inputMessagesFilterMyMentions";
        }
    }
}