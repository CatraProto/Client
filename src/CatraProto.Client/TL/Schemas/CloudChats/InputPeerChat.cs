using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPeerChat : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
    {
        public static int StaticConstructorId
        {
            get => 900291769;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


    #nullable enable
        public InputPeerChat(long chatId)
        {
            ChatId = chatId;
        }
    #nullable disable
        internal InputPeerChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputPeerChat";
        }
    }
}