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
    public partial class BotInlineMessageMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ReplyMarkup = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1970903652; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("geo")] public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("address")]
        public string Address { get; set; }

        [Newtonsoft.Json.JsonProperty("provider")]
        public string Provider { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_id")]
        public string VenueId { get; set; }

        [Newtonsoft.Json.JsonProperty("venue_type")]
        public string VenueType { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_markup")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


#nullable enable
        public BotInlineMessageMediaVenue(CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo, string title, string address, string provider, string venueId, string venueType)
        {
            Geo = geo;
            Title = title;
            Address = address;
            Provider = provider;
            VenueId = venueId;
            VenueType = venueType;
        }
#nullable disable
        internal BotInlineMessageMediaVenue()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
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

            writer.WriteString(Title);

            writer.WriteString(Address);

            writer.WriteString(Provider);

            writer.WriteString(VenueId);

            writer.WriteString(VenueType);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkreplyMarkup = writer.WriteObject(ReplyMarkup);
                if (checkreplyMarkup.IsError)
                {
                    return checkreplyMarkup;
                }
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
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryaddress = reader.ReadString();
            if (tryaddress.IsError)
            {
                return ReadResult<IObject>.Move(tryaddress);
            }

            Address = tryaddress.Value;
            var tryprovider = reader.ReadString();
            if (tryprovider.IsError)
            {
                return ReadResult<IObject>.Move(tryprovider);
            }

            Provider = tryprovider.Value;
            var tryvenueId = reader.ReadString();
            if (tryvenueId.IsError)
            {
                return ReadResult<IObject>.Move(tryvenueId);
            }

            VenueId = tryvenueId.Value;
            var tryvenueType = reader.ReadString();
            if (tryvenueType.IsError)
            {
                return ReadResult<IObject>.Move(tryvenueType);
            }

            VenueType = tryvenueType.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
                if (tryreplyMarkup.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyMarkup);
                }

                ReplyMarkup = tryreplyMarkup.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botInlineMessageMediaVenue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInlineMessageMediaVenue();
            newClonedObject.Flags = Flags;
            var cloneGeo = (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase?)Geo.Clone();
            if (cloneGeo is null)
            {
                return null;
            }

            newClonedObject.Geo = cloneGeo;
            newClonedObject.Title = Title;
            newClonedObject.Address = Address;
            newClonedObject.Provider = Provider;
            newClonedObject.VenueId = VenueId;
            newClonedObject.VenueType = VenueType;
            if (ReplyMarkup is not null)
            {
                var cloneReplyMarkup = (CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase?)ReplyMarkup.Clone();
                if (cloneReplyMarkup is null)
                {
                    return null;
                }

                newClonedObject.ReplyMarkup = cloneReplyMarkup;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInlineMessageMediaVenue castedOther)
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

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Address != castedOther.Address)
            {
                return true;
            }

            if (Provider != castedOther.Provider)
            {
                return true;
            }

            if (VenueId != castedOther.VenueId)
            {
                return true;
            }

            if (VenueType != castedOther.VenueType)
            {
                return true;
            }

            if (ReplyMarkup is null && castedOther.ReplyMarkup is not null || ReplyMarkup is not null && castedOther.ReplyMarkup is null)
            {
                return true;
            }

            if (ReplyMarkup is not null && castedOther.ReplyMarkup is not null && ReplyMarkup.Compare(castedOther.ReplyMarkup))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}