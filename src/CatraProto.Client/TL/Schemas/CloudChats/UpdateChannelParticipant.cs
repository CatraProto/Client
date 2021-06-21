using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChannelParticipant : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PrevParticipant = 1 << 0,
            NewParticipant = 1 << 1
        }

        public static int ConstructorId { get; } = 1708307556;
        public int Flags { get; set; }
        public int ChannelId { get; set; }
        public int Date { get; set; }
        public int UserId { get; set; }
        public ChannelParticipantBase PrevParticipant { get; set; }
        public ChannelParticipantBase NewParticipant { get; set; }
        public int Qts { get; set; }

        public override void UpdateFlags()
        {
            Flags = PrevParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = NewParticipant == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChannelId);
            writer.Write(Date);
            writer.Write(UserId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(PrevParticipant);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(NewParticipant);
            }

            writer.Write(Qts);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ChannelId = reader.Read<int>();
            Date = reader.Read<int>();
            UserId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                PrevParticipant = reader.Read<ChannelParticipantBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                NewParticipant = reader.Read<ChannelParticipantBase>();
            }

            Qts = reader.Read<int>();
        }
    }
}