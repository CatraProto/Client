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
    public partial class StatsAbsValueAndPrev : CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -884757282; }

        [Newtonsoft.Json.JsonProperty("current")]
        public sealed override double Current { get; set; }

        [Newtonsoft.Json.JsonProperty("previous")]
        public sealed override double Previous { get; set; }


#nullable enable
        public StatsAbsValueAndPrev(double current, double previous)
        {
            Current = current;
            Previous = previous;

        }
#nullable disable
        internal StatsAbsValueAndPrev()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Current);

            writer.WriteDouble(Previous);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycurrent = reader.ReadDouble();
            if (trycurrent.IsError)
            {
                return ReadResult<IObject>.Move(trycurrent);
            }
            Current = trycurrent.Value;
            var tryprevious = reader.ReadDouble();
            if (tryprevious.IsError)
            {
                return ReadResult<IObject>.Move(tryprevious);
            }
            Previous = tryprevious.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsAbsValueAndPrev";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsAbsValueAndPrev
            {
                Current = Current,
                Previous = Previous
            };
            return newClonedObject;

        }
#nullable disable
    }
}