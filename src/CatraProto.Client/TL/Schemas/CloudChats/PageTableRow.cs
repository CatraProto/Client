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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageTableRow : CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -524237339; }

        [Newtonsoft.Json.JsonProperty("cells")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }


#nullable enable
        public PageTableRow(List<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> cells)
        {
            Cells = cells;

        }
#nullable disable
        internal PageTableRow()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcells = writer.WriteVector(Cells, false);
            if (checkcells.IsError)
            {
                return checkcells;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycells = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycells.IsError)
            {
                return ReadResult<IObject>.Move(trycells);
            }
            Cells = trycells.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageTableRow";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageTableRow
            {
                Cells = new List<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>()
            };
            foreach (var cells in Cells)
            {
                var clonecells = (CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase?)cells.Clone();
                if (clonecells is null)
                {
                    return null;
                }
                newClonedObject.Cells.Add(clonecells);
            }
            return newClonedObject;

        }
#nullable disable
    }
}