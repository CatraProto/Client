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
    public partial class StatsPercentValue : CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -875679776; }

        [Newtonsoft.Json.JsonProperty("part")]
        public sealed override double Part { get; set; }

        [Newtonsoft.Json.JsonProperty("total")]
        public sealed override double Total { get; set; }


#nullable enable
        public StatsPercentValue(double part, double total)
        {
            Part = part;
            Total = total;

        }
#nullable disable
        internal StatsPercentValue()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Part);

            writer.WriteDouble(Total);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypart = reader.ReadDouble();
            if (trypart.IsError)
            {
                return ReadResult<IObject>.Move(trypart);
            }
            Part = trypart.Value;
            var trytotal = reader.ReadDouble();
            if (trytotal.IsError)
            {
                return ReadResult<IObject>.Move(trytotal);
            }
            Total = trytotal.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsPercentValue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsPercentValue
            {
                Part = Part,
                Total = Total
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsPercentValue castedOther)
            {
                return true;
            }
            if (Part != castedOther.Part)
            {
                return true;
            }
            if (Total != castedOther.Total)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}