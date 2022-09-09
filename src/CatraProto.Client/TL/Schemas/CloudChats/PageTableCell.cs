using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 878078826; }

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

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var checktext = writer.WriteObject(Text);
                if (checktext.IsError)
                {
                    return checktext;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Colspan.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(Rowspan.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Header = FlagsHelper.IsFlagSet(Flags, 0);
            AlignCenter = FlagsHelper.IsFlagSet(Flags, 3);
            AlignRight = FlagsHelper.IsFlagSet(Flags, 4);
            ValignMiddle = FlagsHelper.IsFlagSet(Flags, 5);
            ValignBottom = FlagsHelper.IsFlagSet(Flags, 6);
            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
                if (trytext.IsError)
                {
                    return ReadResult<IObject>.Move(trytext);
                }

                Text = trytext.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trycolspan = reader.ReadInt32();
                if (trycolspan.IsError)
                {
                    return ReadResult<IObject>.Move(trycolspan);
                }

                Colspan = trycolspan.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryrowspan = reader.ReadInt32();
                if (tryrowspan.IsError)
                {
                    return ReadResult<IObject>.Move(tryrowspan);
                }

                Rowspan = tryrowspan.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageTableCell";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageTableCell();
            newClonedObject.Flags = Flags;
            newClonedObject.Header = Header;
            newClonedObject.AlignCenter = AlignCenter;
            newClonedObject.AlignRight = AlignRight;
            newClonedObject.ValignMiddle = ValignMiddle;
            newClonedObject.ValignBottom = ValignBottom;
            if (Text is not null)
            {
                var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
                if (cloneText is null)
                {
                    return null;
                }

                newClonedObject.Text = cloneText;
            }

            newClonedObject.Colspan = Colspan;
            newClonedObject.Rowspan = Rowspan;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageTableCell castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Header != castedOther.Header)
            {
                return true;
            }

            if (AlignCenter != castedOther.AlignCenter)
            {
                return true;
            }

            if (AlignRight != castedOther.AlignRight)
            {
                return true;
            }

            if (ValignMiddle != castedOther.ValignMiddle)
            {
                return true;
            }

            if (ValignBottom != castedOther.ValignBottom)
            {
                return true;
            }

            if (Text is null && castedOther.Text is not null || Text is not null && castedOther.Text is null)
            {
                return true;
            }

            if (Text is not null && castedOther.Text is not null && Text.Compare(castedOther.Text))
            {
                return true;
            }

            if (Colspan != castedOther.Colspan)
            {
                return true;
            }

            if (Rowspan != castedOther.Rowspan)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}