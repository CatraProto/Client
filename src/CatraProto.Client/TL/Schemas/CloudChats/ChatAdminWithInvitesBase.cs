using CatraProto.TL;
using System.Collections.Generic;
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
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
