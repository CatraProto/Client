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
    public partial class PageListItemBlocks : CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 635466748; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }


#nullable enable
        public PageListItemBlocks(List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks)
        {
            Blocks = blocks;

        }
#nullable disable
        internal PageListItemBlocks()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblocks.IsError)
            {
                return ReadResult<IObject>.Move(tryblocks);
            }
            Blocks = tryblocks.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageListItemBlocks";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageListItemBlocks
            {
                Blocks = new List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>()
            };
            foreach (var blocks in Blocks)
            {
                var cloneblocks = (CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase?)blocks.Clone();
                if (cloneblocks is null)
                {
                    return null;
                }
                newClonedObject.Blocks.Add(cloneblocks);
            }
            return newClonedObject;

        }
#nullable disable
    }
}