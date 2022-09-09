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
    public partial class ChatAdminWithInvites : CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -219353309; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public sealed override long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("invites_count")]
        public sealed override int InvitesCount { get; set; }

        [Newtonsoft.Json.JsonProperty("revoked_invites_count")]
        public sealed override int RevokedInvitesCount { get; set; }


#nullable enable
        public ChatAdminWithInvites(long adminId, int invitesCount, int revokedInvitesCount)
        {
            AdminId = adminId;
            InvitesCount = invitesCount;
            RevokedInvitesCount = revokedInvitesCount;
        }
#nullable disable
        internal ChatAdminWithInvites()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(AdminId);
            writer.WriteInt32(InvitesCount);
            writer.WriteInt32(RevokedInvitesCount);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryadminId = reader.ReadInt64();
            if (tryadminId.IsError)
            {
                return ReadResult<IObject>.Move(tryadminId);
            }

            AdminId = tryadminId.Value;
            var tryinvitesCount = reader.ReadInt32();
            if (tryinvitesCount.IsError)
            {
                return ReadResult<IObject>.Move(tryinvitesCount);
            }

            InvitesCount = tryinvitesCount.Value;
            var tryrevokedInvitesCount = reader.ReadInt32();
            if (tryrevokedInvitesCount.IsError)
            {
                return ReadResult<IObject>.Move(tryrevokedInvitesCount);
            }

            RevokedInvitesCount = tryrevokedInvitesCount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatAdminWithInvites";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatAdminWithInvites();
            newClonedObject.AdminId = AdminId;
            newClonedObject.InvitesCount = InvitesCount;
            newClonedObject.RevokedInvitesCount = RevokedInvitesCount;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatAdminWithInvites castedOther)
            {
                return true;
            }

            if (AdminId != castedOther.AdminId)
            {
                return true;
            }

            if (InvitesCount != castedOther.InvitesCount)
            {
                return true;
            }

            if (RevokedInvitesCount != castedOther.RevokedInvitesCount)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}