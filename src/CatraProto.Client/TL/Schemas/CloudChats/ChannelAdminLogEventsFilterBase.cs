using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChannelAdminLogEventsFilterBase : IObject
    {

[JsonPropertyName("join")]
		public abstract bool Join { get; set; }

[JsonPropertyName("leave")]
		public abstract bool Leave { get; set; }

[JsonPropertyName("invite")]
		public abstract bool Invite { get; set; }

[JsonPropertyName("ban")]
		public abstract bool Ban { get; set; }

[JsonPropertyName("unban")]
		public abstract bool Unban { get; set; }

[JsonPropertyName("kick")]
		public abstract bool Kick { get; set; }

[JsonPropertyName("unkick")]
		public abstract bool Unkick { get; set; }

[JsonPropertyName("promote")]
		public abstract bool Promote { get; set; }

[JsonPropertyName("demote")]
		public abstract bool Demote { get; set; }

[JsonPropertyName("info")]
		public abstract bool Info { get; set; }

[JsonPropertyName("settings")]
		public abstract bool Settings { get; set; }

[JsonPropertyName("pinned")]
		public abstract bool Pinned { get; set; }

[JsonPropertyName("edit")]
		public abstract bool Edit { get; set; }

[JsonPropertyName("delete")]
		public abstract bool Delete { get; set; }

[JsonPropertyName("group_call")]
		public abstract bool GroupCall { get; set; }

[JsonPropertyName("invites")]
		public abstract bool Invites { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
