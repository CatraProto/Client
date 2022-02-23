using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatParticipantAdd : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => 1037718609;
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

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


    #nullable enable
        public UpdateChatParticipantAdd(long chatId, long userId, long inviterId, int date, int version)
        {
            ChatId = chatId;
            UserId = userId;
            InviterId = inviterId;
            Date = date;
            Version = version;
        }
    #nullable disable
        internal UpdateChatParticipantAdd()
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
            writer.Write(InviterId);
            writer.Write(Date);
            writer.Write(Version);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
            UserId = reader.Read<long>();
            InviterId = reader.Read<long>();
            Date = reader.Read<int>();
            Version = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateChatParticipantAdd";
        }
    }
}