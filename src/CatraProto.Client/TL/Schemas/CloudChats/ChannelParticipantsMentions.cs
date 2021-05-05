using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantsMentions : ChannelParticipantsFilterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Q = 1 << 0,
            TopMsgId = 1 << 1
        }

        public static int ConstructorId { get; } = -531931925;
        public int Flags { get; set; }
        public string Q { get; set; }
        public int? TopMsgId { get; set; }

        public override void UpdateFlags()
        {
            Flags = Q == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Q);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(TopMsgId.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Q = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                TopMsgId = reader.Read<int>();
            }
        }
    }
}