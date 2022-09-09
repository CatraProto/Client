using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditLocation : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1491484525; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }


#nullable enable
        public EditLocation(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string address)
        {
            Channel = channel;
            GeoPoint = geoPoint;
            Address = address;
        }
#nullable disable

        internal EditLocation()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            var checkgeoPoint = writer.WriteObject(GeoPoint);
            if (checkgeoPoint.IsError)
            {
                return checkgeoPoint;
            }

            writer.WriteString(Address);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
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
            return "channels.editLocation";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditLocation();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }

            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.Address = Address;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditLocation castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
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