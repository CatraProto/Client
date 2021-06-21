using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantAdmin : ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanEdit = 1 << 0,
            Self = 1 << 1,
            InviterId = 1 << 1,
            Rank = 1 << 2
        }

        public static int ConstructorId { get; } = -859915345;
        public int Flags { get; set; }
        public bool CanEdit { get; set; }
        public bool Self { get; set; }
        public override int UserId { get; set; }
        public int? InviterId { get; set; }
        public int PromotedBy { get; set; }
        public int Date { get; set; }
        public ChatAdminRightsBase AdminRights { get; set; }
        public string Rank { get; set; }

        public override void UpdateFlags()
        {
            Flags = CanEdit ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Self ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = InviterId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(UserId);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(InviterId.Value);
            }

            writer.Write(PromotedBy);
            writer.Write(Date);
            writer.Write(AdminRights);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Rank);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CanEdit = FlagsHelper.IsFlagSet(Flags, 0);
            Self = FlagsHelper.IsFlagSet(Flags, 1);
            UserId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                InviterId = reader.Read<int>();
            }

            PromotedBy = reader.Read<int>();
            Date = reader.Read<int>();
            AdminRights = reader.Read<ChatAdminRightsBase>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Rank = reader.Read<string>();
            }
        }
    }
}