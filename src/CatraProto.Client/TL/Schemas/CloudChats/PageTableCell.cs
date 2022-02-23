using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageTableCell : CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Header = 1 << 0,
            AlignCenter = 1 << 3,
            AlignRight = 1 << 4,
            ValignMiddle = 1 << 5,
            ValignBottom = 1 << 6,
            Text = 1 << 7,
            Colspan = 1 << 1,
            Rowspan = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => 878078826;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("header")]
        public sealed override bool Header { get; set; }

        [Newtonsoft.Json.JsonProperty("align_center")]
        public sealed override bool AlignCenter { get; set; }

        [Newtonsoft.Json.JsonProperty("align_right")]
        public sealed override bool AlignRight { get; set; }

        [Newtonsoft.Json.JsonProperty("valign_middle")]
        public sealed override bool ValignMiddle { get; set; }

        [Newtonsoft.Json.JsonProperty("valign_bottom")]
        public sealed override bool ValignBottom { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("colspan")]
        public sealed override int? Colspan { get; set; }

        [Newtonsoft.Json.JsonProperty("rowspan")]
        public sealed override int? Rowspan { get; set; }


        public PageTableCell()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Header ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AlignCenter ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = AlignRight ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = ValignMiddle ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = ValignBottom ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = Text == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = Colspan == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Rowspan == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.Write(Text);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Colspan.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Rowspan.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Header = FlagsHelper.IsFlagSet(Flags, 0);
            AlignCenter = FlagsHelper.IsFlagSet(Flags, 3);
            AlignRight = FlagsHelper.IsFlagSet(Flags, 4);
            ValignMiddle = FlagsHelper.IsFlagSet(Flags, 5);
            ValignBottom = FlagsHelper.IsFlagSet(Flags, 6);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Colspan = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Rowspan = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "pageTableCell";
        }
    }
}