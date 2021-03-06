/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1085412734; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bordered")]
        public bool Bordered { get; set; }

        [Newtonsoft.Json.JsonProperty("striped")]
        public bool Striped { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Title { get; set; }

        [Newtonsoft.Json.JsonProperty("rows")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase> Rows { get; set; }


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
            var newClonedObject = new PageBlockTable
            {
                Flags = Flags,
                Bordered = Bordered,
                Striped = Striped
            };
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