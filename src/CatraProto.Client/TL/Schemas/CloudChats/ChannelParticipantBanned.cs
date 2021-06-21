using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantBanned : ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Left = 1 << 0
        }

        public static int ConstructorId { get; } = 470789295;
        public int Flags { get; set; }
        public bool Left { get; set; }
        public override int UserId { get; set; }
        public int KickedBy { get; set; }
        public int Date { get; set; }
        public ChatBannedRightsBase BannedRights { get; set; }

        public override void UpdateFlags()
        {
            Flags = Left ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            writer.Write(KickedBy);
            writer.Write(Date);
            writer.Write(BannedRights);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Left = FlagsHelper.IsFlagSet(Flags, 0);
            UserId = reader.Read<int>();
            KickedBy = reader.Read<int>();
            Date = reader.Read<int>();
            BannedRights = reader.Read<ChatBannedRightsBase>();
        }
    }
}