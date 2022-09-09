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
    public partial class User : CatraProto.Client.TL.Schemas.CloudChats.UserBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Self = 1 << 10,
            Contact = 1 << 11,
            MutualContact = 1 << 12,
            Deleted = 1 << 13,
            Bot = 1 << 14,
            BotChatHistory = 1 << 15,
            BotNochats = 1 << 16,
            Verified = 1 << 17,
            Restricted = 1 << 18,
            Min = 1 << 20,
            BotInlineGeo = 1 << 21,
            Support = 1 << 23,
            Scam = 1 << 24,
            ApplyMinPhoto = 1 << 25,
            Fake = 1 << 26,
            BotAttachMenu = 1 << 27,
            Premium = 1 << 28,
            AttachMenuEnabled = 1 << 29,
            AccessHash = 1 << 0,
            FirstName = 1 << 1,
            LastName = 1 << 2,
            Username = 1 << 3,
            Phone = 1 << 4,
            Photo = 1 << 5,
            Status = 1 << 6,
            BotInfoVersion = 1 << 14,
            RestrictionReason = 1 << 18,
            BotInlinePlaceholder = 1 << 19,
            LangCode = 1 << 22
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1073147056; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("self")] public bool Self { get; set; }

        [Newtonsoft.Json.JsonProperty("contact")]
        public bool Contact { get; set; }

        [Newtonsoft.Json.JsonProperty("mutual_contact")]
        public bool MutualContact { get; set; }

        [Newtonsoft.Json.JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")] public bool Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_chat_history")]
        public bool BotChatHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_nochats")]
        public bool BotNochats { get; set; }

        [Newtonsoft.Json.JsonProperty("verified")]
        public bool Verified { get; set; }

        [Newtonsoft.Json.JsonProperty("restricted")]
        public bool Restricted { get; set; }

        [Newtonsoft.Json.JsonProperty("min")] public bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_inline_geo")]
        public bool BotInlineGeo { get; set; }

        [Newtonsoft.Json.JsonProperty("support")]
        public bool Support { get; set; }

        [Newtonsoft.Json.JsonProperty("scam")] public bool Scam { get; set; }

        [Newtonsoft.Json.JsonProperty("apply_min_photo")]
        public bool ApplyMinPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("fake")] public bool Fake { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_attach_menu")]
        public bool BotAttachMenu { get; set; }

        [Newtonsoft.Json.JsonProperty("premium")]
        public bool Premium { get; set; }

        [Newtonsoft.Json.JsonProperty("attach_menu_enabled")]
        public bool AttachMenuEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long? AccessHash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("phone")]
        public string Phone { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase Photo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("status")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_info_version")]
        public int? BotInfoVersion { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("restriction_reason")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase> RestrictionReason { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_inline_placeholder")]
        public string BotInlinePlaceholder { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


#nullable enable
        public User(long id)
        {
            Id = id;
        }
#nullable disable
        internal User()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Self ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = Contact ? FlagsHelper.SetFlag(Flags, 11) : FlagsHelper.UnsetFlag(Flags, 11);
            Flags = MutualContact ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = Deleted ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = Bot ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = BotChatHistory ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
            Flags = BotNochats ? FlagsHelper.SetFlag(Flags, 16) : FlagsHelper.UnsetFlag(Flags, 16);
            Flags = Verified ? FlagsHelper.SetFlag(Flags, 17) : FlagsHelper.UnsetFlag(Flags, 17);
            Flags = Restricted ? FlagsHelper.SetFlag(Flags, 18) : FlagsHelper.UnsetFlag(Flags, 18);
            Flags = Min ? FlagsHelper.SetFlag(Flags, 20) : FlagsHelper.UnsetFlag(Flags, 20);
            Flags = BotInlineGeo ? FlagsHelper.SetFlag(Flags, 21) : FlagsHelper.UnsetFlag(Flags, 21);
            Flags = Support ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
            Flags = Scam ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
            Flags = ApplyMinPhoto ? FlagsHelper.SetFlag(Flags, 25) : FlagsHelper.UnsetFlag(Flags, 25);
            Flags = Fake ? FlagsHelper.SetFlag(Flags, 26) : FlagsHelper.UnsetFlag(Flags, 26);
            Flags = BotAttachMenu ? FlagsHelper.SetFlag(Flags, 27) : FlagsHelper.UnsetFlag(Flags, 27);
            Flags = Premium ? FlagsHelper.SetFlag(Flags, 28) : FlagsHelper.UnsetFlag(Flags, 28);
            Flags = AttachMenuEnabled ? FlagsHelper.SetFlag(Flags, 29) : FlagsHelper.UnsetFlag(Flags, 29);
            Flags = AccessHash == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = FirstName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = LastName == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Username == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Phone == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = Status == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = BotInfoVersion == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
            Flags = RestrictionReason == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
            Flags = BotInlinePlaceholder == null ? FlagsHelper.UnsetFlag(Flags, 19) : FlagsHelper.SetFlag(Flags, 19);
            Flags = LangCode == null ? FlagsHelper.UnsetFlag(Flags, 22) : FlagsHelper.SetFlag(Flags, 22);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(AccessHash.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(FirstName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(LastName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Username);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteString(Phone);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var checkstatus = writer.WriteObject(Status);
                if (checkstatus.IsError)
                {
                    return checkstatus;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                writer.WriteInt32(BotInfoVersion.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var checkrestrictionReason = writer.WriteVector(RestrictionReason, false);
                if (checkrestrictionReason.IsError)
                {
                    return checkrestrictionReason;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 19))
            {
                writer.WriteString(BotInlinePlaceholder);
            }

            if (FlagsHelper.IsFlagSet(Flags, 22))
            {
                writer.WriteString(LangCode);
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
            Self = FlagsHelper.IsFlagSet(Flags, 10);
            Contact = FlagsHelper.IsFlagSet(Flags, 11);
            MutualContact = FlagsHelper.IsFlagSet(Flags, 12);
            Deleted = FlagsHelper.IsFlagSet(Flags, 13);
            Bot = FlagsHelper.IsFlagSet(Flags, 14);
            BotChatHistory = FlagsHelper.IsFlagSet(Flags, 15);
            BotNochats = FlagsHelper.IsFlagSet(Flags, 16);
            Verified = FlagsHelper.IsFlagSet(Flags, 17);
            Restricted = FlagsHelper.IsFlagSet(Flags, 18);
            Min = FlagsHelper.IsFlagSet(Flags, 20);
            BotInlineGeo = FlagsHelper.IsFlagSet(Flags, 21);
            Support = FlagsHelper.IsFlagSet(Flags, 23);
            Scam = FlagsHelper.IsFlagSet(Flags, 24);
            ApplyMinPhoto = FlagsHelper.IsFlagSet(Flags, 25);
            Fake = FlagsHelper.IsFlagSet(Flags, 26);
            BotAttachMenu = FlagsHelper.IsFlagSet(Flags, 27);
            Premium = FlagsHelper.IsFlagSet(Flags, 28);
            AttachMenuEnabled = FlagsHelper.IsFlagSet(Flags, 29);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryaccessHash = reader.ReadInt64();
                if (tryaccessHash.IsError)
                {
                    return ReadResult<IObject>.Move(tryaccessHash);
                }

                AccessHash = tryaccessHash.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryfirstName = reader.ReadString();
                if (tryfirstName.IsError)
                {
                    return ReadResult<IObject>.Move(tryfirstName);
                }

                FirstName = tryfirstName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trylastName = reader.ReadString();
                if (trylastName.IsError)
                {
                    return ReadResult<IObject>.Move(trylastName);
                }

                LastName = trylastName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryusername = reader.ReadString();
                if (tryusername.IsError)
                {
                    return ReadResult<IObject>.Move(tryusername);
                }

                Username = tryusername.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryphone = reader.ReadString();
                if (tryphone.IsError)
                {
                    return ReadResult<IObject>.Move(tryphone);
                }

                Phone = tryphone.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trystatus = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase>();
                if (trystatus.IsError)
                {
                    return ReadResult<IObject>.Move(trystatus);
                }

                Status = trystatus.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var trybotInfoVersion = reader.ReadInt32();
                if (trybotInfoVersion.IsError)
                {
                    return ReadResult<IObject>.Move(trybotInfoVersion);
                }

                BotInfoVersion = trybotInfoVersion.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var tryrestrictionReason = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryrestrictionReason.IsError)
                {
                    return ReadResult<IObject>.Move(tryrestrictionReason);
                }

                RestrictionReason = tryrestrictionReason.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 19))
            {
                var trybotInlinePlaceholder = reader.ReadString();
                if (trybotInlinePlaceholder.IsError)
                {
                    return ReadResult<IObject>.Move(trybotInlinePlaceholder);
                }

                BotInlinePlaceholder = trybotInlinePlaceholder.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 22))
            {
                var trylangCode = reader.ReadString();
                if (trylangCode.IsError)
                {
                    return ReadResult<IObject>.Move(trylangCode);
                }

                LangCode = trylangCode.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "user";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new User();
            newClonedObject.Flags = Flags;
            newClonedObject.Self = Self;
            newClonedObject.Contact = Contact;
            newClonedObject.MutualContact = MutualContact;
            newClonedObject.Deleted = Deleted;
            newClonedObject.Bot = Bot;
            newClonedObject.BotChatHistory = BotChatHistory;
            newClonedObject.BotNochats = BotNochats;
            newClonedObject.Verified = Verified;
            newClonedObject.Restricted = Restricted;
            newClonedObject.Min = Min;
            newClonedObject.BotInlineGeo = BotInlineGeo;
            newClonedObject.Support = Support;
            newClonedObject.Scam = Scam;
            newClonedObject.ApplyMinPhoto = ApplyMinPhoto;
            newClonedObject.Fake = Fake;
            newClonedObject.BotAttachMenu = BotAttachMenu;
            newClonedObject.Premium = Premium;
            newClonedObject.AttachMenuEnabled = AttachMenuEnabled;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.Username = Username;
            newClonedObject.Phone = Phone;
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }

                newClonedObject.Photo = clonePhoto;
            }

            if (Status is not null)
            {
                var cloneStatus = (CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase?)Status.Clone();
                if (cloneStatus is null)
                {
                    return null;
                }

                newClonedObject.Status = cloneStatus;
            }

            newClonedObject.BotInfoVersion = BotInfoVersion;
            if (RestrictionReason is not null)
            {
                newClonedObject.RestrictionReason = new List<CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase>();
                foreach (var restrictionReason in RestrictionReason)
                {
                    var clonerestrictionReason = (CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase?)restrictionReason.Clone();
                    if (clonerestrictionReason is null)
                    {
                        return null;
                    }

                    newClonedObject.RestrictionReason.Add(clonerestrictionReason);
                }
            }

            newClonedObject.BotInlinePlaceholder = BotInlinePlaceholder;
            newClonedObject.LangCode = LangCode;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not User castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Self != castedOther.Self)
            {
                return true;
            }

            if (Contact != castedOther.Contact)
            {
                return true;
            }

            if (MutualContact != castedOther.MutualContact)
            {
                return true;
            }

            if (Deleted != castedOther.Deleted)
            {
                return true;
            }

            if (Bot != castedOther.Bot)
            {
                return true;
            }

            if (BotChatHistory != castedOther.BotChatHistory)
            {
                return true;
            }

            if (BotNochats != castedOther.BotNochats)
            {
                return true;
            }

            if (Verified != castedOther.Verified)
            {
                return true;
            }

            if (Restricted != castedOther.Restricted)
            {
                return true;
            }

            if (Min != castedOther.Min)
            {
                return true;
            }

            if (BotInlineGeo != castedOther.BotInlineGeo)
            {
                return true;
            }

            if (Support != castedOther.Support)
            {
                return true;
            }

            if (Scam != castedOther.Scam)
            {
                return true;
            }

            if (ApplyMinPhoto != castedOther.ApplyMinPhoto)
            {
                return true;
            }

            if (Fake != castedOther.Fake)
            {
                return true;
            }

            if (BotAttachMenu != castedOther.BotAttachMenu)
            {
                return true;
            }

            if (Premium != castedOther.Premium)
            {
                return true;
            }

            if (AttachMenuEnabled != castedOther.AttachMenuEnabled)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (FirstName != castedOther.FirstName)
            {
                return true;
            }

            if (LastName != castedOther.LastName)
            {
                return true;
            }

            if (Username != castedOther.Username)
            {
                return true;
            }

            if (Phone != castedOther.Phone)
            {
                return true;
            }

            if (Photo is null && castedOther.Photo is not null || Photo is not null && castedOther.Photo is null)
            {
                return true;
            }

            if (Photo is not null && castedOther.Photo is not null && Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (Status is null && castedOther.Status is not null || Status is not null && castedOther.Status is null)
            {
                return true;
            }

            if (Status is not null && castedOther.Status is not null && Status.Compare(castedOther.Status))
            {
                return true;
            }

            if (BotInfoVersion != castedOther.BotInfoVersion)
            {
                return true;
            }

            if (RestrictionReason is null && castedOther.RestrictionReason is not null || RestrictionReason is not null && castedOther.RestrictionReason is null)
            {
                return true;
            }

            if (RestrictionReason is not null && castedOther.RestrictionReason is not null)
            {
                var restrictionReasonsize = castedOther.RestrictionReason.Count;
                if (restrictionReasonsize != RestrictionReason.Count)
                {
                    return true;
                }

                for (var i = 0; i < restrictionReasonsize; i++)
                {
                    if (castedOther.RestrictionReason[i].Compare(RestrictionReason[i]))
                    {
                        return true;
                    }
                }
            }

            if (BotInlinePlaceholder != castedOther.BotInlinePlaceholder)
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}