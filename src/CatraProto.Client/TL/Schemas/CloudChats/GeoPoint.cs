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
    public partial class GeoPoint : CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase
    {
        [Flags]
        public enum FlagsEnum
        {
            AccuracyRadius = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1297942941; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("long")] public double Long { get; set; }

        [Newtonsoft.Json.JsonProperty("lat")] public double Lat { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("accuracy_radius")]
        public int? AccuracyRadius { get; set; }


#nullable enable
        public GeoPoint(double llong, double lat, long accessHash)
        {
            Long = llong;
            Lat = lat;
            AccessHash = accessHash;
        }
#nullable disable
        internal GeoPoint()
        {
        }

        public override void UpdateFlags()
        {
            Flags = AccuracyRadius == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteDouble(Long);

            writer.WriteDouble(Lat);
            writer.WriteInt64(AccessHash);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(AccuracyRadius.Value);
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
            var tryllong = reader.ReadDouble();
            if (tryllong.IsError)
            {
                return ReadResult<IObject>.Move(tryllong);
            }

            Long = tryllong.Value;
            var trylat = reader.ReadDouble();
            if (trylat.IsError)
            {
                return ReadResult<IObject>.Move(trylat);
            }

            Lat = trylat.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryaccuracyRadius = reader.ReadInt32();
                if (tryaccuracyRadius.IsError)
                {
                    return ReadResult<IObject>.Move(tryaccuracyRadius);
                }

                AccuracyRadius = tryaccuracyRadius.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "geoPoint";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GeoPoint();
            newClonedObject.Flags = Flags;
            newClonedObject.Long = Long;
            newClonedObject.Lat = Lat;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.AccuracyRadius = AccuracyRadius;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GeoPoint castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Long != castedOther.Long)
            {
                return true;
            }

            if (Lat != castedOther.Lat)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (AccuracyRadius != castedOther.AccuracyRadius)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}