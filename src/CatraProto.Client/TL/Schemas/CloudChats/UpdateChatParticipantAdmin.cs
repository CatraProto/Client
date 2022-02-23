using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -674602590;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


    #nullable enable
        public UpdateChatParticipantAdmin(long chatId, long userId, bool isAdmin, int version)
        {
            ChatId = chatId;
            UserId = userId;
            IsAdmin = isAdmin;
            Version = version;
        }
    #nullable disable
        internal UpdateChatParticipantAdmin()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(UserId);
            writer.Write(IsAdmin);
            writer.Write(Version);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
            UserId = reader.Read<long>();
            IsAdmin = reader.Read<bool>();
            Version = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateChatParticipantAdmin";
        }
    }
}