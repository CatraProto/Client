using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelForbidden : ChatBase
    {
        public static int ConstructorId { get; } = 681420594;
        public int Flags { get; set; }
        public bool Broadcast { get; set; }
        public bool Megagroup { get; set; }
        public override int Id { get; set; }
        public long AccessHash { get; set; }
        public string Title { get; set; }
        public int? UntilDate { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Broadcast = 1 << 5,
            Megagroup = 1 << 8,
            UntilDate = 1 << 16
        }

        public override void UpdateFlags()
        {
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = UntilDate == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(Title);
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.Write(UntilDate.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Broadcast = FlagsHelper.IsFlagSet(Flags, 5);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 8);
            Id = reader.Read<int>();
            AccessHash = reader.Read<long>();
            Title = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                UntilDate = reader.Read<int>();
            }
        }
    }
}