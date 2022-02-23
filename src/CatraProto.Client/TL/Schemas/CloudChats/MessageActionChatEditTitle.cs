using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatEditTitle : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1247687078;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


    #nullable enable
        public MessageActionChatEditTitle(string title)
        {
            Title = title;
        }
    #nullable disable
        internal MessageActionChatEditTitle()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Title);
        }

        public override void Deserialize(Reader reader)
        {
            Title = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messageActionChatEditTitle";
        }
    }
}