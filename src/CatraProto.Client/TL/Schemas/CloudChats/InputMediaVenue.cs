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
    public partial class InputMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1052959727; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("provider")]
        public string Provider { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_id")]
        public string VenueId { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_type")]
        public string VenueType { get; set; }


#nullable enable
        public InputMediaVenue(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string title, string address, string provider, string venueId, string venueType)
        {
            GeoPoint = geoPoint;
            Title = title;
            Address = address;
            Provider = provider;
            VenueId = venueId;
            VenueType = venueType;

        }
#nullable disable
        internal InputMediaVenue()
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

            writer.WriteString(Title);

            writer.WriteString(Address);

            writer.WriteString(Provider);

            writer.WriteString(VenueId);

            writer.WriteString(VenueType);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            if (trygeoPoint.IsError)
            {
                return ReadResult<IObject>.Move(trygeoPoint);
            }
            GeoPoint = trygeoPoint.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var tryaddress = reader.ReadString();
            if (tryaddress.IsError)
            {
                return ReadResult<IObject>.Move(tryaddress);
            }
            Address = tryaddress.Value;
            var tryprovider = reader.ReadString();
            if (tryprovider.IsError)
            {
                return ReadResult<IObject>.Move(tryprovider);
            }
            Provider = tryprovider.Value;
            var tryvenueId = reader.ReadString();
            if (tryvenueId.IsError)
            {
                return ReadResult<IObject>.Move(tryvenueId);
            }
            VenueId = tryvenueId.Value;
            var tryvenueType = reader.ReadString();
            if (tryvenueType.IsError)
            {
                return ReadResult<IObject>.Move(tryvenueType);
            }
            VenueType = tryvenueType.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputMediaVenue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaVenue();
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }
            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.Title = Title;
            newClonedObject.Address = Address;
            newClonedObject.Provider = Provider;
            newClonedObject.VenueId = VenueId;
            newClonedObject.VenueType = VenueType;
            return newClonedObject;

        }
#nullable disable
    }
}