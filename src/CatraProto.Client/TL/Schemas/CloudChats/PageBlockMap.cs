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
    public partial class PageBlockMap : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1538310410; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public int Zoom { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


#nullable enable
        public PageBlockMap(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo, int zoom, int w, int h, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Geo = geo;
            Zoom = zoom;
            W = w;
            H = h;
            Caption = caption;
        }
#nullable disable
        internal PageBlockMap()
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

            writer.WriteInt32(Zoom);
            writer.WriteInt32(W);
            writer.WriteInt32(H);
            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
            }

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
            var tryzoom = reader.ReadInt32();
            if (tryzoom.IsError)
            {
                return ReadResult<IObject>.Move(tryzoom);
            }

            Zoom = tryzoom.Value;
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
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }

            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockMap";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockMap();
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }

            newClonedObject.Geo = cloneGeo;
            newClonedObject.Zoom = Zoom;
            newClonedObject.W = W;
            newClonedObject.H = H;
            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }

            newClonedObject.Caption = cloneCaption;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockMap castedOther)
            {
                return true;
            }

            if (Geo.Compare(castedOther.Geo))
            {
                return true;
            }

            if (Zoom != castedOther.Zoom)
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

            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}