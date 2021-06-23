using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class DraftMessageEmpty : DraftMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Date = 1 << 0
        }

        public static int ConstructorId { get; } = 453805082;
        public int Flags { get; set; }
        public override int? Date { get; set; }

        public override void UpdateFlags()
        {
            Flags = Date == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Date.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Date = reader.Read<int>();
            }
        }
    }
}