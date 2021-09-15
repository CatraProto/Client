using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChannelAdminLogEventsFilterBase : IObject
    {

[Newtonsoft.Json.JsonProperty("join")]
		public abstract bool Join { get; set; }

[Newtonsoft.Json.JsonProperty("leave")]
		public abstract bool Leave { get; set; }

[Newtonsoft.Json.JsonProperty("invite")]
		public abstract bool Invite { get; set; }

[Newtonsoft.Json.JsonProperty("ban")]
		public abstract bool Ban { get; set; }

[Newtonsoft.Json.JsonProperty("unban")]
		public abstract bool Unban { get; set; }

[Newtonsoft.Json.JsonProperty("kick")]
		public abstract bool Kick { get; set; }

[Newtonsoft.Json.JsonProperty("unkick")]
		public abstract bool Unkick { get; set; }

[Newtonsoft.Json.JsonProperty("promote")]
		public abstract bool Promote { get; set; }

[Newtonsoft.Json.JsonProperty("demote")]
		public abstract bool Demote { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public abstract bool Info { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public abstract bool Settings { get; set; }

[Newtonsoft.Json.JsonProperty("pinned")]
		public abstract bool Pinned { get; set; }

[Newtonsoft.Json.JsonProperty("edit")]
		public abstract bool Edit { get; set; }

[Newtonsoft.Json.JsonProperty("delete")]
		public abstract bool Delete { get; set; }

[Newtonsoft.Json.JsonProperty("group_call")]
		public abstract bool GroupCall { get; set; }

[Newtonsoft.Json.JsonProperty("invites")]
		public abstract bool Invites { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
