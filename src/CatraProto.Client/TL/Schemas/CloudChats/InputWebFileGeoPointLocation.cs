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
    public partial class InputWebFileGeoPointLocation : CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1625153079; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public int Zoom { get; set; }

        [Newtonsoft.Json.JsonProperty("scale")]
        public int Scale { get; set; }


#nullable enable
        public InputWebFileGeoPointLocation(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, long accessHash, int w, int h, int zoom, int scale)
        {
            GeoPoint = geoPoint;
            AccessHash = accessHash;
            W = w;
            H = h;
            Zoom = zoom;
            Scale = scale;
        }
#nullable disable
        internal InputWebFileGeoPointLocation()
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

            writer.WriteInt64(AccessHash);
            writer.WriteInt32(W);
            writer.WriteInt32(H);
            writer.WriteInt32(Zoom);
            writer.WriteInt32(Scale);

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
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }

            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }

            H = tryh.Value;
            var tryzoom = reader.ReadInt32();
            if (tryzoom.IsError)
            {
                return ReadResult<IObject>.Move(tryzoom);
            }

            Zoom = tryzoom.Value;
            var tryscale = reader.ReadInt32();
            if (tryscale.IsError)
            {
                return ReadResult<IObject>.Move(tryscale);
            }

            Scale = tryscale.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputWebFileGeoPointLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWebFileGeoPointLocation();
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }

            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.W = W;
            newClonedObject.H = H;
            newClonedObject.Zoom = Zoom;
            newClonedObject.Scale = Scale;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputWebFileGeoPointLocation castedOther)
            {
                return true;
            }

            if (GeoPoint.Compare(castedOther.GeoPoint))
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (W != castedOther.W)
            {
                return true;
            }

            if (H != castedOther.H)
            {
                return true;
            }

            if (Zoom != castedOther.Zoom)
            {
                return true;
            }

            if (Scale != castedOther.Scale)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}