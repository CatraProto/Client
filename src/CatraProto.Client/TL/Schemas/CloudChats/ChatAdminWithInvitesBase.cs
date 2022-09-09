using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatAdminWithInvitesBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("admin_id")]
        public abstract long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("invites_count")]
        public abstract int InvitesCount { get; set; }

        [Newtonsoft.Json.JsonProperty("revoked_invites_count")]
        public abstract int RevokedInvitesCount { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}