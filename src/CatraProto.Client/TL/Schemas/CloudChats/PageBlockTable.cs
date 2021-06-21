using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockTable : PageBlockBase
    {
        public static int ConstructorId { get; } = -1085412734;
        public int Flags { get; set; }
        public bool Bordered { get; set; }
        public bool Striped { get; set; }
        public RichTextBase Title { get; set; }
        public IList<PageTableRowBase> Rows { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Bordered = 1 << 0,
            Striped = 1 << 1
        }

        public override void UpdateFlags()
        {
            Flags = Bordered ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Striped ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Title);
            writer.Write(Rows);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Bordered = FlagsHelper.IsFlagSet(Flags, 0);
            Striped = FlagsHelper.IsFlagSet(Flags, 1);
            Title = reader.Read<RichTextBase>();
            Rows = reader.ReadVector<PageTableRowBase>();
        }
    }
}