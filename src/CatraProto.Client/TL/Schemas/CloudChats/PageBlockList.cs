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
    public partial class PageBlockList : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -454524911; }

        [Newtonsoft.Json.JsonProperty("items")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> Items { get; set; }


#nullable enable
        public PageBlockList(List<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> items)
        {
            Items = items;

        }
#nullable disable
        internal PageBlockList()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkitems = writer.WriteVector(Items, false);
            if (checkitems.IsError)
            {
                return checkitems;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryitems = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryitems.IsError)
            {
                return ReadResult<IObject>.Move(tryitems);
            }
            Items = tryitems.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockList";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockList
            {
                Items = new List<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase>()
            };
            foreach (var items in Items)
            {
                var cloneitems = (CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase?)items.Clone();
                if (cloneitems is null)
                {
                    return null;
                }
                newClonedObject.Items.Add(cloneitems);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockList castedOther)
            {
                return true;
            }
            var itemssize = castedOther.Items.Count;
            if (itemssize != Items.Count)
            {
                return true;
            }
            for (var i = 0; i < itemssize; i++)
            {
                if (castedOther.Items[i].Compare(Items[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}