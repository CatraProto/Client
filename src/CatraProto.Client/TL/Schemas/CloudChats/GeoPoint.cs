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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1297942941; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("long")]
        public double Long { get; set; }

        [Newtonsoft.Json.JsonProperty("lat")]
        public double Lat { get; set; }

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
            var newClonedObject = new GeoPoint
            {
                Flags = Flags,
                Long = Long,
                Lat = Lat,
                AccessHash = AccessHash,
                AccuracyRadius = AccuracyRadius
            };
            return newClonedObject;

        }
#nullable disable
    }
}