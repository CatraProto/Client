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
    public partial class ChannelLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 547062491; }

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