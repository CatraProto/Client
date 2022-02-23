using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EncryptedChatWaiting : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        public static int StaticConstructorId
        {
            get => 1722964307;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("participant_id")]
        public long ParticipantId { get; set; }


    #nullable enable
        public EncryptedChatWaiting(int id, long accessHash, int date, long adminId, long participantId)
        {
            Id = id;
            AccessHash = accessHash;
            Date = date;
            AdminId = adminId;
            ParticipantId = participantId;
        }
    #nullable disable
        internal EncryptedChatWaiting()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(Date);
            writer.Write(AdminId);
            writer.Write(ParticipantId);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
            AccessHash = reader.Read<long>();
            Date = reader.Read<int>();
            AdminId = reader.Read<long>();
            ParticipantId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "encryptedChatWaiting";
        }
    }
}