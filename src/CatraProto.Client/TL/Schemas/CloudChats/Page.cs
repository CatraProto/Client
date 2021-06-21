using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Page : PageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Part = 1 << 0,
            Rtl = 1 << 1,
            V2 = 1 << 2,
            Views = 1 << 3
        }

        public static int ConstructorId { get; } = -1738178803;
        public int Flags { get; set; }
        public override bool Part { get; set; }
        public override bool Rtl { get; set; }
        public override bool V2 { get; set; }
        public override string Url { get; set; }
        public override IList<PageBlockBase> Blocks { get; set; }
        public override IList<PhotoBase> Photos { get; set; }
        public override IList<DocumentBase> Documents { get; set; }
        public override int? Views { get; set; }

        public override void UpdateFlags()
        {
            Flags = Part ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Rtl ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = V2 ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Url);
            writer.Write(Blocks);
            writer.Write(Photos);
            writer.Write(Documents);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Views.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Part = FlagsHelper.IsFlagSet(Flags, 0);
            Rtl = FlagsHelper.IsFlagSet(Flags, 1);
            V2 = FlagsHelper.IsFlagSet(Flags, 2);
            Url = reader.Read<string>();
            Blocks = reader.ReadVector<PageBlockBase>();
            Photos = reader.ReadVector<PhotoBase>();
            Documents = reader.ReadVector<DocumentBase>();
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Views = reader.Read<int>();
            }
        }
    }
}