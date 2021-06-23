using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateChatParticipants : UpdateBase
    {
        public static int ConstructorId { get; } = 125178264;
        public ChatParticipantsBase Participants { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Participants);
        }

        public override void Deserialize(Reader reader)
        {
            Participants = reader.Read<ChatParticipantsBase>();
        }
    }
}