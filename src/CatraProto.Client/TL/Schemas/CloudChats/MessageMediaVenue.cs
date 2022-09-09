using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 784356159; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

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
        public MessageMediaVenue(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo, string title, string address, string provider, string venueId, string venueType)
        {
            Geo = geo;
            Title = title;
            Address = address;
            Provider = provider;
            VenueId = venueId;
            VenueType = venueType;
        }
#nullable disable
        internal MessageMediaVenue()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkgeo = writer.WriteObject(Geo);
            if (checkgeo.IsError)
            {
                return checkgeo;
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
            var trygeo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            if (trygeo.IsError)
            {
                return ReadResult<IObject>.Move(trygeo);
            }

            Geo = trygeo.Value;
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
            return "messageMediaVenue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaVenue();
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }

            newClonedObject.Geo = cloneGeo;
            newClonedObject.Title = Title;
            newClonedObject.Address = Address;
            newClonedObject.Provider = Provider;
            newClonedObject.VenueId = VenueId;
            newClonedObject.VenueType = VenueType;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaVenue castedOther)
            {
                return true;
            }

            if (Geo.Compare(castedOther.Geo))
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Address != castedOther.Address)
            {
                return true;
            }

            if (Provider != castedOther.Provider)
            {
                return true;
            }

            if (VenueId != castedOther.VenueId)
            {
                return true;
            }

            if (VenueType != castedOther.VenueType)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}