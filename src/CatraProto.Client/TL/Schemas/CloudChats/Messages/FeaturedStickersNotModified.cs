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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FeaturedStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -958657434; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }


#nullable enable
        public FeaturedStickersNotModified(int count)
        {
            Count = count;

        }
#nullable disable
        internal FeaturedStickersNotModified()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.featuredStickersNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FeaturedStickersNotModified
            {
                Count = Count
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not FeaturedStickersNotModified castedOther)
            {
                return true;
            }
            if (Count != castedOther.Count)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}