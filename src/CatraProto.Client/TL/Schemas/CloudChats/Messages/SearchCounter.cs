using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SearchCounter : SearchCounterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inexact = 1 << 1
        }

        public static int ConstructorId { get; } = -398136321;
        public int Flags { get; set; }
        public override bool Inexact { get; set; }
        public override MessagesFilterBase Filter { get; set; }
        public override int Count { get; set; }

        public override void UpdateFlags()
        {
            Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Filter);
            writer.Write(Count);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Inexact = FlagsHelper.IsFlagSet(Flags, 1);
            Filter = reader.Read<MessagesFilterBase>();
            Count = reader.Read<int>();
        }
    }
}