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
    public partial class ChannelLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 547062491; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }


#nullable enable
        public ChannelLocation(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geoPoint, string address)
        {
            GeoPoint = geoPoint;
            Address = address;

        }
#nullable disable
        internal ChannelLocation()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkgeoPoint = writer.WriteObject(GeoPoint);
            if (checkgeoPoint.IsError)
            {
                return checkgeoPoint;
            }

            writer.WriteString(Address);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            if (trygeoPoint.IsError)
            {
                return ReadResult<IObject>.Move(trygeoPoint);
            }
            GeoPoint = trygeoPoint.Value;
            var tryaddress = reader.ReadString();
            if (tryaddress.IsError)
            {
                return ReadResult<IObject>.Move(tryaddress);
            }
            Address = tryaddress.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelLocation();
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }
            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.Address = Address;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelLocation castedOther)
            {
                return true;
            }
            if (GeoPoint.Compare(castedOther.GeoPoint))
            {
                return true;
            }
            if (Address != castedOther.Address)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}