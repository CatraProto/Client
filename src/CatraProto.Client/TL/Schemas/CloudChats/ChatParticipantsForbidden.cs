using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantsForbidden : ChatParticipantsBase
    {
        public static int ConstructorId { get; } = -57668565;
        public int Flags { get; set; }
        public override int ChatId { get; set; }
        public ChatParticipantBase SelfParticipant { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            SelfParticipant = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = SelfParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChatId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(SelfParticipant);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ChatId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                SelfParticipant = reader.Read<ChatParticipantBase>();
            }
        }
    }
}