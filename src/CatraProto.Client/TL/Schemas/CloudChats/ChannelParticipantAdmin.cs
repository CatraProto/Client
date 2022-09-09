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
    public partial class ChannelParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanEdit = 1 << 0,
            Self = 1 << 1,
            InviterId = 1 << 1,
            Rank = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 885242707; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_edit")]
        public bool CanEdit { get; set; }

        [Newtonsoft.Json.JsonProperty("self")] public bool Self { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long? InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("promoted_by")]
        public long PromotedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("rank")]
        public string Rank { get; set; }


#nullable enable
        public ChannelParticipantAdmin(long userId, long promotedBy, int date, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights)
        {
            UserId = userId;
            PromotedBy = promotedBy;
            Date = date;
            AdminRights = adminRights;
        }
#nullable disable
        internal ChannelParticipantAdmin()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CanEdit ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Self ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = InviterId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(UserId);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt64(InviterId.Value);
            }

            writer.WriteInt64(PromotedBy);
            writer.WriteInt32(Date);
            var checkadminRights = writer.WriteObject(AdminRights);
            if (checkadminRights.IsError)
            {
                return checkadminRights;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteString(Rank);
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
            CanEdit = FlagsHelper.IsFlagSet(Flags, 0);
            Self = FlagsHelper.IsFlagSet(Flags, 1);
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryinviterId = reader.ReadInt64();
                if (tryinviterId.IsError)
                {
                    return ReadResult<IObject>.Move(tryinviterId);
                }

                InviterId = tryinviterId.Value;
            }

            var trypromotedBy = reader.ReadInt64();
            if (trypromotedBy.IsError)
            {
                return ReadResult<IObject>.Move(trypromotedBy);
            }

            PromotedBy = trypromotedBy.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryadminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
            if (tryadminRights.IsError)
            {
                return ReadResult<IObject>.Move(tryadminRights);
            }

            AdminRights = tryadminRights.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryrank = reader.ReadString();
                if (tryrank.IsError)
                {
                    return ReadResult<IObject>.Move(tryrank);
                }

                Rank = tryrank.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantAdmin();
            newClonedObject.Flags = Flags;
            newClonedObject.CanEdit = CanEdit;
            newClonedObject.Self = Self;
            newClonedObject.UserId = UserId;
            newClonedObject.InviterId = InviterId;
            newClonedObject.PromotedBy = PromotedBy;
            newClonedObject.Date = Date;
            var cloneAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)AdminRights.Clone();
            if (cloneAdminRights is null)
            {
                return null;
            }

            newClonedObject.AdminRights = cloneAdminRights;
            newClonedObject.Rank = Rank;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantAdmin castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CanEdit != castedOther.CanEdit)
            {
                return true;
            }

            if (Self != castedOther.Self)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (InviterId != castedOther.InviterId)
            {
                return true;
            }

            if (PromotedBy != castedOther.PromotedBy)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (AdminRights.Compare(castedOther.AdminRights))
            {
                return true;
            }

            if (Rank != castedOther.Rank)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}