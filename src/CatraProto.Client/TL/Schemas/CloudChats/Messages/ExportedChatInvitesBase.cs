using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class ExportedChatInvitesBase : IObject
    {

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

[Newtonsoft.Json.JsonProperty("invites")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase> Invites { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
