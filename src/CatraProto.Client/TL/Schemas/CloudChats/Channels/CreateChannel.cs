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
    public partial class CreateChannel : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Broadcast = 1 << 0,
            Megagroup = 1 << 1,
            ForImport = 1 << 3,
            GeoPoint = 1 << 2,
            Address = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1029681423; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public bool Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup")]
        public bool Megagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("for_import")]
        public bool ForImport { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("geo_point")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }


#nullable enable
        public CreateChannel(string title, string about)
        {
            Title = title;
            About = about;
        }
#nullable disable

        internal CreateChannel()
        {
        }

        public void UpdateFlags()
        {
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = ForImport ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Address == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Title);

            writer.WriteString(About);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkgeoPoint = writer.WriteObject(GeoPoint);
                if (checkgeoPoint.IsError)
                {
                    return checkgeoPoint;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Address);
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
            Broadcast = FlagsHelper.IsFlagSet(Flags, 0);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 1);
            ForImport = FlagsHelper.IsFlagSet(Flags, 3);
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryabout = reader.ReadString();
            if (tryabout.IsError)
            {
                return ReadResult<IObject>.Move(tryabout);
            }

            About = tryabout.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trygeoPoint = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
                if (trygeoPoint.IsError)
                {
                    return ReadResult<IObject>.Move(trygeoPoint);
                }

                GeoPoint = trygeoPoint.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryaddress = reader.ReadString();
                if (tryaddress.IsError)
                {
                    return ReadResult<IObject>.Move(tryaddress);
                }

                Address = tryaddress.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channels.createChannel";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CreateChannel();
            newClonedObject.Flags = Flags;
            newClonedObject.Broadcast = Broadcast;
            newClonedObject.Megagroup = Megagroup;
            newClonedObject.ForImport = ForImport;
            newClonedObject.Title = Title;
            newClonedObject.About = About;
            if (GeoPoint is not null)
            {
                var cloneGeoPoint = (CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase?)GeoPoint.Clone();
                if (cloneGeoPoint is null)
                {
                    return null;
                }

                newClonedObject.GeoPoint = cloneGeoPoint;
            }

            newClonedObject.Address = Address;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CreateChannel castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Broadcast != castedOther.Broadcast)
            {
                return true;
            }

            if (Megagroup != castedOther.Megagroup)
            {
                return true;
            }

            if (ForImport != castedOther.ForImport)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (GeoPoint is null && castedOther.GeoPoint is not null || GeoPoint is not null && castedOther.GeoPoint is null)
            {
                return true;
            }

            if (GeoPoint is not null && castedOther.GeoPoint is not null && GeoPoint.Compare(castedOther.GeoPoint))
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