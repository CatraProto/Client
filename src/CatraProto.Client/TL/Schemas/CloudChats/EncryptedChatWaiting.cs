using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EncryptedChatWaiting : EncryptedChatBase
    {
        public static int ConstructorId { get; } = 1006044124;
        public override int Id { get; set; }
        public long AccessHash { get; set; }
        public int Date { get; set; }
        public int AdminId { get; set; }
        public int ParticipantId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
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
            AdminId = reader.Read<int>();
            ParticipantId = reader.Read<int>();
        }
    }
}