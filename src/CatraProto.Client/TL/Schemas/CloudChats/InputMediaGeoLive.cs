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
    public partial class InputMediaGeoLive : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Stopped = 1 << 0,
            Heading = 1 << 2,
            Period = 1 << 1,
            ProximityNotificationRadius = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1759532989; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("stopped")]
        public bool Stopped { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("heading")]
        public int? Heading { get; set; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int? Period { get; set; }

        [Newtonsoft.Json.JsonProperty("proximity_notification_radius")]
        public int? ProximityNotificationRadius { get; set; }


#nullable enable
        public InputMediaGeoLive(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint)
        {
            GeoPoint = geoPoint;
        }
#nullable disable
        internal InputMediaGeoLive()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Stopped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Period == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkgeoPoint = writer.WriteObject(GeoPoint);
            if (checkgeoPoint.IsError)
            {
                return checkgeoPoint;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(Heading.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(Period.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
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
            Stopped = FlagsHelper.IsFlagSet(Flags, 0);
            var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            if (trygeoPoint.IsError)
            {
                return ReadResult<IObject>.Move(trygeoPoint);
            }

            GeoPoint = trygeoPoint.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryheading = reader.ReadInt32();
                if (tryheading.IsError)
                {
                    return ReadResult<IObject>.Move(tryheading);
                }

                Heading = tryheading.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryperiod = reader.ReadInt32();
                if (tryperiod.IsError)
                {
                    return ReadResult<IObject>.Move(tryperiod);
                }

                Period = tryperiod.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
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
            return "inputMediaGeoLive";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaGeoLive();
            newClonedObject.Flags = Flags;
            newClonedObject.Stopped = Stopped;
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }

            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.Heading = Heading;
            newClonedObject.Period = Period;
            newClonedObject.ProximityNotificationRadius = ProximityNotificationRadius;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMediaGeoLive castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Stopped != castedOther.Stopped)
            {
                return true;
            }

            if (GeoPoint.Compare(castedOther.GeoPoint))
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