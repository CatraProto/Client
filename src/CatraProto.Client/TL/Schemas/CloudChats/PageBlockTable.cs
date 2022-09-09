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
    public partial class PageBlockTable : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Bordered = 1 << 0,
            Striped = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1085412734; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bordered")]
        public bool Bordered { get; set; }

        [Newtonsoft.Json.JsonProperty("striped")]
        public bool Striped { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

        [Newtonsoft.Json.JsonProperty("rows")] public List<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> Rows { get; set; }


#nullable enable
        public PageBlockTable(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase title, List<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> rows)
        {
            Title = title;
            Rows = rows;
        }
#nullable disable
        internal PageBlockTable()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Bordered ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Striped ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checktitle = writer.WriteObject(Title);
            if (checktitle.IsError)
            {
                return checktitle;
            }

            var checkrows = writer.WriteVector(Rows, false);
            if (checkrows.IsError)
            {
                return checkrows;
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
            Bordered = FlagsHelper.IsFlagSet(Flags, 0);
            Striped = FlagsHelper.IsFlagSet(Flags, 1);
            var trytitle = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryrows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrows.IsError)
            {
                return ReadResult<IObject>.Move(tryrows);
            }

            Rows = tryrows.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockTable";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockTable();
            newClonedObject.Flags = Flags;
            newClonedObject.Bordered = Bordered;
            newClonedObject.Striped = Striped;
            var cloneTitle = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Title.Clone();
            if (cloneTitle is null)
            {
                return null;
            }

            newClonedObject.Title = cloneTitle;
            newClonedObject.Rows = new List<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase>();
            foreach (var rows in Rows)
            {
                var clonerows = (CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase?)rows.Clone();
                if (clonerows is null)
                {
                    return null;
                }

                newClonedObject.Rows.Add(clonerows);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockTable castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Bordered != castedOther.Bordered)
            {
                return true;
            }

            if (Striped != castedOther.Striped)
            {
                return true;
            }

            if (Title.Compare(castedOther.Title))
            {
                return true;
            }

            var rowssize = castedOther.Rows.Count;
            if (rowssize != Rows.Count)
            {
                return true;
            }

            for (var i = 0; i < rowssize; i++)
            {
                if (castedOther.Rows[i].Compare(Rows[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}