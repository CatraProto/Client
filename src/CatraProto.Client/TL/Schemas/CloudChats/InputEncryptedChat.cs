using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputEncryptedChat : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase
    {
        public static int StaticConstructorId
        {
            get => -247351839;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override int ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }


    #nullable enable
        public InputEncryptedChat(int chatId, long accessHash)
        {
            ChatId = chatId;
            AccessHash = accessHash;
        }
    #nullable disable
        internal InputEncryptedChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            AccessHash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputEncryptedChat";
        }
    }
}