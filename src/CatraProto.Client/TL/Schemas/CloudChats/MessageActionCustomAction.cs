using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionCustomAction : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -85549226;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }


    #nullable enable
        public MessageActionCustomAction(string message)
        {
            Message = message;
        }
    #nullable disable
        internal MessageActionCustomAction()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Message);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messageActionCustomAction";
        }
    }
}