using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateChatParticipantAdmin : UpdateBase
    {
        public static int ConstructorId { get; } = -1232070311;
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public int Version { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
            writer.Write(UserId);
            writer.Write(IsAdmin);
            writer.Write(Version);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            UserId = reader.Read<int>();
            IsAdmin = reader.Read<bool>();
            Version = reader.Read<int>();
        }
    }
}