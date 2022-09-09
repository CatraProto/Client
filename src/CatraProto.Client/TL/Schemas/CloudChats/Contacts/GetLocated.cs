using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetLocated : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Background = 1 << 1,
            SelfExpires = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -750207932; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("background")]
        public bool Background { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [Newtonsoft.Json.JsonProperty("self_expires")]
        public int? SelfExpires { get; set; }


#nullable enable
        public GetLocated(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint)
        {
            GeoPoint = geoPoint;
        }
#nullable disable

        internal GetLocated()
        {
        }

        public void UpdateFlags()
        {
            Flags = Background ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = SelfExpires == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkgeoPoint = writer.WriteObject(GeoPoint);
            if (checkgeoPoint.IsError)
            {
                return checkgeoPoint;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(SelfExpires.Value);
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Background = FlagsHelper.IsFlagSet(Flags, 1);
            var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
            if (trygeoPoint.IsError)
            {
                return ReadResult<IObject>.Move(trygeoPoint);
            }

            GeoPoint = trygeoPoint.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryselfExpires = reader.ReadInt32();
                if (tryselfExpires.IsError)
                {
                    return ReadResult<IObject>.Move(tryselfExpires);
                }

                SelfExpires = tryselfExpires.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.getLocated";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetLocated();
            newClonedObject.Flags = Flags;
            newClonedObject.Background = Background;
            var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
            if (cloneGeoPoint is null)
            {
                return null;
            }

            newClonedObject.GeoPoint = cloneGeoPoint;
            newClonedObject.SelfExpires = SelfExpires;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetLocated castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Background != castedOther.Background)
            {
                return true;
            }

            if (GeoPoint.Compare(castedOther.GeoPoint))
            {
                return true;
            }

            if (SelfExpires != castedOther.SelfExpires)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}