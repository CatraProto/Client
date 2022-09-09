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
    public partial class MessageMediaGeoLive : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Heading = 1 << 0,
            ProximityNotificationRadius = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1186937242; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("heading")]
        public int? Heading { get; set; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }

        [Newtonsoft.Json.JsonProperty("proximity_notification_radius")]
        public int? ProximityNotificationRadius { get; set; }


#nullable enable
        public MessageMediaGeoLive(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo, int period)
        {
            Geo = geo;
            Period = period;
        }
#nullable disable
        internal MessageMediaGeoLive()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkgeo = writer.WriteObject(Geo);
            if (checkgeo.IsError)
            {
                return checkgeo;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Heading.Value);
            }

            writer.WriteInt32(Period);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(ProximityNotificationRadius.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trygeo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
            if (trygeo.IsError)
            {
                return ReadResult<IObject>.Move(trygeo);
            }

            Geo = trygeo.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryheading = reader.ReadInt32();
                if (tryheading.IsError)
                {
                    return ReadResult<IObject>.Move(tryheading);
                }

                Heading = tryheading.Value;
            }

            var tryperiod = reader.ReadInt32();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }

            Period = tryperiod.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryproximityNotificationRadius = reader.ReadInt32();
                if (tryproximityNotificationRadius.IsError)
                {
                    return ReadResult<IObject>.Move(tryproximityNotificationRadius);
                }

                ProximityNotificationRadius = tryproximityNotificationRadius.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageMediaGeoLive";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaGeoLive();
            newClonedObject.Flags = Flags;
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }

            newClonedObject.Geo = cloneGeo;
            newClonedObject.Heading = Heading;
            newClonedObject.Period = Period;
            newClonedObject.ProximityNotificationRadius = ProximityNotificationRadius;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaGeoLive castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Geo.Compare(castedOther.Geo))
            {
                return true;
            }

            if (Heading != castedOther.Heading)
            {
                return true;
            }

            if (Period != castedOther.Period)
            {
                return true;
            }

            if (ProximityNotificationRadius != castedOther.ProximityNotificationRadius)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}