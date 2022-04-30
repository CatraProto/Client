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

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeWithMessagesRange : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 911373810; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("range")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase Range { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InvokeWithMessagesRange(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query)
        {
            Range = range;
            Query = query;

        }
#nullable disable

        internal InvokeWithMessagesRange()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkrange = writer.WriteObject(Range);
            if (checkrange.IsError)
            {
                return checkrange;
            }
            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrange = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
            if (tryrange.IsError)
            {
                return ReadResult<IObject>.Move(tryrange);
            }
            Range = tryrange.Value;
            var tryquery = reader.ReadObject<IObject>();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }
            Query = tryquery.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "invokeWithMessagesRange";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InvokeWithMessagesRange();
            var cloneRange = (CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase?)Range.Clone();
            if (cloneRange is null)
            {
                return null;
            }
            newClonedObject.Range = cloneRange;
            newClonedObject.Query = Query;
            return newClonedObject;

        }
#nullable disable
    }
}