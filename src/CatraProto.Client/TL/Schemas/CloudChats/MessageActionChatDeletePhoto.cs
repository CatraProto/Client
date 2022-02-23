using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatDeletePhoto : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1780220945;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public MessageActionChatDeletePhoto()
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
            return "messageActionChatDeletePhoto";
        }
    }
}