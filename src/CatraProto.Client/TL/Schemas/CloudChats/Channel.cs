using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Channel : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Creator = 1 << 0,
            Left = 1 << 2,
            Broadcast = 1 << 5,
            Verified = 1 << 7,
            Megagroup = 1 << 8,
            Restricted = 1 << 9,
            Signatures = 1 << 11,
            Min = 1 << 12,
            Scam = 1 << 19,
            HasLink = 1 << 20,
            HasGeo = 1 << 21,
            SlowmodeEnabled = 1 << 22,
            CallActive = 1 << 23,
            CallNotEmpty = 1 << 24,
            Fake = 1 << 25,
            Gigagroup = 1 << 26,
            Noforwards = 1 << 27,
            AccessHash = 1 << 13,
            Username = 1 << 6,
            RestrictionReason = 1 << 9,
            AdminRights = 1 << 14,
            BannedRights = 1 << 15,
            DefaultBannedRights = 1 << 18,
            ParticipantsCount = 1 << 17
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2107528095; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("creator")]
        public bool Creator { get; set; }

        [Newtonsoft.Json.JsonProperty("left")]
        public bool Left { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public bool Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("verified")]
        public bool Verified { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup")]
        public bool Megagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("restricted")]
        public bool Restricted { get; set; }

        [Newtonsoft.Json.JsonProperty("signatures")]
        public bool Signatures { get; set; }

        [Newtonsoft.Json.JsonProperty("min")]
        public bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("scam")]
        public bool Scam { get; set; }

        [Newtonsoft.Json.JsonProperty("has_link")]
        public bool HasLink { get; set; }

        [Newtonsoft.Json.JsonProperty("has_geo")]
        public bool HasGeo { get; set; }

        [Newtonsoft.Json.JsonProperty("slowmode_enabled")]
        public bool SlowmodeEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("call_active")]
        public bool CallActive { get; set; }

        [Newtonsoft.Json.JsonProperty("call_not_empty")]
        public bool CallNotEmpty { get; set; }

        [Newtonsoft.Json.JsonProperty("fake")]
        public bool Fake { get; set; }

        [Newtonsoft.Json.JsonProperty("gigagroup")]
        public bool Gigagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("noforwards")]
        public bool Noforwards { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long? AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("restriction_reason")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase> RestrictionReason { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("default_banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }

        [Newtonsoft.Json.JsonProperty("participants_count")]
        public int? ParticipantsCount { get; set; }


#nullable enable
        public Channel(long id, string title, CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase photo, int date)
        {
            Id = id;
            Title = title;
            Photo = photo;
            Date = date;

        }
#nullable disable
        internal Channel()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Left ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Verified ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = Restricted ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
            Flags = Signatures ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = Min ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = Scam ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
            Flags = HasLink ? FlagsHelper.SetFlag(Flags, 20) : FlagsHelper.UnsetFlag(Flags, 20);
            Flags = HasGeo ? FlagsHelper.SetFlag(Flags, 21) : FlagsHelper.UnsetFlag(Flags, 21);
            Flags = SlowmodeEnabled ? FlagsHelper.SetFlag(Flags, 22) : FlagsHelper.UnsetFlag(Flags, 22);
            Flags = CallActive ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
            Flags = CallNotEmpty ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
            Flags = Fake ? FlagsHelper.SetFlag(Flags, 25) : FlagsHelper.UnsetFlag(Flags, 25);
            Flags = Gigagroup ? FlagsHelper.SetFlag(Flags, 26) : FlagsHelper.UnsetFlag(Flags, 26);
            Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 27) : FlagsHelper.UnsetFlag(Flags, 27);
            Flags = AccessHash == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
            Flags = Username == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = RestrictionReason == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = AdminRights == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
            Flags = BannedRights == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
            Flags = DefaultBannedRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
            Flags = ParticipantsCount == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                writer.WriteInt64(AccessHash.Value);
            }


            writer.WriteString(Title);
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {

                writer.WriteString(Username);
            }

            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var checkrestrictionReason = writer.WriteVector(RestrictionReason, false);
                if (checkrestrictionReason.IsError)
                {
                    return checkrestrictionReason;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var checkadminRights = writer.WriteObject(AdminRights);
                if (checkadminRights.IsError)
                {
                    return checkadminRights;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var checkbannedRights = writer.WriteObject(BannedRights);
                if (checkbannedRights.IsError)
                {
                    return checkbannedRights;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var checkdefaultBannedRights = writer.WriteObject(DefaultBannedRights);
                if (checkdefaultBannedRights.IsError)
                {
                    return checkdefaultBannedRights;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.WriteInt32(ParticipantsCount.Value);
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
            Creator = FlagsHelper.IsFlagSet(Flags, 0);
            Left = FlagsHelper.IsFlagSet(Flags, 2);
            Broadcast = FlagsHelper.IsFlagSet(Flags, 5);
            Verified = FlagsHelper.IsFlagSet(Flags, 7);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 8);
            Restricted = FlagsHelper.IsFlagSet(Flags, 9);
            Signatures = FlagsHelper.IsFlagSet(Flags, 11);
            Min = FlagsHelper.IsFlagSet(Flags, 12);
            Scam = FlagsHelper.IsFlagSet(Flags, 19);
            HasLink = FlagsHelper.IsFlagSet(Flags, 20);
            HasGeo = FlagsHelper.IsFlagSet(Flags, 21);
            SlowmodeEnabled = FlagsHelper.IsFlagSet(Flags, 22);
            CallActive = FlagsHelper.IsFlagSet(Flags, 23);
            CallNotEmpty = FlagsHelper.IsFlagSet(Flags, 24);
            Fake = FlagsHelper.IsFlagSet(Flags, 25);
            Gigagroup = FlagsHelper.IsFlagSet(Flags, 26);
            Noforwards = FlagsHelper.IsFlagSet(Flags, 27);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var tryaccessHash = reader.ReadInt64();
                if (tryaccessHash.IsError)
                {
                    return ReadResult<IObject>.Move(tryaccessHash);
                }
                AccessHash = tryaccessHash.Value;
            }

            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var tryusername = reader.ReadString();
                if (tryusername.IsError)
                {
                    return ReadResult<IObject>.Move(tryusername);
                }
                Username = tryusername.Value;
            }

            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }
            Photo = tryphoto.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var tryrestrictionReason = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryrestrictionReason.IsError)
                {
                    return ReadResult<IObject>.Move(tryrestrictionReason);
                }
                RestrictionReason = tryrestrictionReason.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var tryadminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
                if (tryadminRights.IsError)
                {
                    return ReadResult<IObject>.Move(tryadminRights);
                }
                AdminRights = tryadminRights.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var trybannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
                if (trybannedRights.IsError)
                {
                    return ReadResult<IObject>.Move(trybannedRights);
                }
                BannedRights = trybannedRights.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var trydefaultBannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
                if (trydefaultBannedRights.IsError)
                {
                    return ReadResult<IObject>.Move(trydefaultBannedRights);
                }
                DefaultBannedRights = trydefaultBannedRights.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var tryparticipantsCount = reader.ReadInt32();
                if (tryparticipantsCount.IsError)
                {
                    return ReadResult<IObject>.Move(tryparticipantsCount);
                }
                ParticipantsCount = tryparticipantsCount.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channel";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}