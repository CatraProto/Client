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
    public partial class SearchResultsCalendarPeriod : CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -911191137; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("min_msg_id")]
        public sealed override int MinMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_msg_id")]
        public sealed override int MaxMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }


#nullable enable
        public SearchResultsCalendarPeriod(int date, int minMsgId, int maxMsgId, int count)
        {
            Date = date;
            MinMsgId = minMsgId;
            MaxMsgId = maxMsgId;
            Count = count;

        }
#nullable disable
        internal SearchResultsCalendarPeriod()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            writer.WriteInt32(MinMsgId);
            writer.WriteInt32(MaxMsgId);
            writer.WriteInt32(Count);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryminMsgId = reader.ReadInt32();
            if (tryminMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryminMsgId);
            }
            MinMsgId = tryminMsgId.Value;
            var trymaxMsgId = reader.ReadInt32();
            if (trymaxMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxMsgId);
            }
            MaxMsgId = trymaxMsgId.Value;
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
            return "searchResultsCalendarPeriod";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchResultsCalendarPeriod
            {
                Date = Date,
                MinMsgId = MinMsgId,
                MaxMsgId = MaxMsgId,
                Count = Count
            };
            return newClonedObject;

        }
#nullable disable
    }
}