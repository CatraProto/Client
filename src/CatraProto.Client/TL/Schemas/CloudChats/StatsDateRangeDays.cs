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
    public partial class StatsDateRangeDays : CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1237848657; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public sealed override int MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public sealed override int MaxDate { get; set; }


#nullable enable
        public StatsDateRangeDays(int minDate, int maxDate)
        {
            MinDate = minDate;
            MaxDate = maxDate;

        }
#nullable disable
        internal StatsDateRangeDays()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MinDate);
            writer.WriteInt32(MaxDate);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryminDate = reader.ReadInt32();
            if (tryminDate.IsError)
            {
                return ReadResult<IObject>.Move(tryminDate);
            }
            MinDate = tryminDate.Value;
            var trymaxDate = reader.ReadInt32();
            if (trymaxDate.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDate);
            }
            MaxDate = trymaxDate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsDateRangeDays";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsDateRangeDays
            {
                MinDate = MinDate,
                MaxDate = MaxDate
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsDateRangeDays castedOther)
            {
                return true;
            }
            if (MinDate != castedOther.MinDate)
            {
                return true;
            }
            if (MaxDate != castedOther.MaxDate)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}