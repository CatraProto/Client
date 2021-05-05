using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipants : ChatParticipantsBase
    {
        public static int ConstructorId { get; } = 1061556205;
        public override int ChatId { get; set; }
        public IList<ChatParticipantBase> Participants { get; set; }
        public int Version { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChatId);
            writer.Write(Participants);
            writer.Write(Version);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            Participants = reader.ReadVector<ChatParticipantBase>();
            Version = reader.Read<int>();
        }
    }
}