using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatParticipantDelete : UpdateBase
    {
        public static int ConstructorId { get; } = 1851755554;
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public int Version { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(UserId);
            writer.Write(Version);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            UserId = reader.Read<int>();
            Version = reader.Read<int>();
        }
    }
}