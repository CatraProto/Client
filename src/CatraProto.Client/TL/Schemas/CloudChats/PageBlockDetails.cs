using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockDetails : PageBlockBase
    {
        public static int ConstructorId { get; } = 1987480557;
        public int Flags { get; set; }
        public bool Open { get; set; }
        public IList<PageBlockBase> Blocks { get; set; }
        public RichTextBase Title { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Open = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = Open ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Blocks);
            writer.Write(Title);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Open = FlagsHelper.IsFlagSet(Flags, 0);
            Blocks = reader.ReadVector<PageBlockBase>();
            Title = reader.Read<RichTextBase>();
        }
    }
}