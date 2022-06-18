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
    public partial class NearestDc : CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1910892683; }

        [Newtonsoft.Json.JsonProperty("country")]
        public sealed override string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("this_dc")]
        public sealed override int ThisDc { get; set; }

        [Newtonsoft.Json.JsonProperty("nearest_dc")]
        public sealed override int NearestDcField { get; set; }


#nullable enable
        public NearestDc(string country, int thisDc, int nearestDcField)
        {
            Country = country;
            ThisDc = thisDc;
            NearestDcField = nearestDcField;

        }
#nullable disable
        internal NearestDc()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Country);
            writer.WriteInt32(ThisDc);
            writer.WriteInt32(NearestDcField);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycountry = reader.ReadString();
            if (trycountry.IsError)
            {
                return ReadResult<IObject>.Move(trycountry);
            }
            Country = trycountry.Value;
            var trythisDc = reader.ReadInt32();
            if (trythisDc.IsError)
            {
                return ReadResult<IObject>.Move(trythisDc);
            }
            ThisDc = trythisDc.Value;
            var trynearestDcField = reader.ReadInt32();
            if (trynearestDcField.IsError)
            {
                return ReadResult<IObject>.Move(trynearestDcField);
            }
            NearestDcField = trynearestDcField.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "nearestDc";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NearestDc
            {
                Country = Country,
                ThisDc = ThisDc,
                NearestDcField = NearestDcField
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not NearestDc castedOther)
            {
                return true;
            }
            if (Country != castedOther.Country)
            {
                return true;
            }
            if (ThisDc != castedOther.ThisDc)
            {
                return true;
            }
            if (NearestDcField != castedOther.NearestDcField)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}