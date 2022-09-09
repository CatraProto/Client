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
    public partial class MessageMediaGeo : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1457575028; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }


#nullable enable
        public MessageMediaGeo(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo)
        {
            Geo = geo;
        }
#nullable disable
        internal MessageMediaGeo()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageMediaGeo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaGeo();
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }

            newClonedObject.Geo = cloneGeo;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaGeo castedOther)
            {
                return true;
            }

            if (Geo.Compare(castedOther.Geo))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}