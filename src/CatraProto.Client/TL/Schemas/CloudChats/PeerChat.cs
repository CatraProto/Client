using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerChat : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {
        public static int StaticConstructorId
        {
            get => 918946202;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


    #nullable enable
        public PeerChat(long chatId)
        {
            ChatId = chatId;
        }
    #nullable disable
        internal PeerChat()
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
            return "peerChat";
        }
    }
}