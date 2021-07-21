using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterBase : IObject
    {

[JsonPropertyName("contacts")]
		public abstract bool Contacts { get; set; }

[JsonPropertyName("non_contacts")]
		public abstract bool NonContacts { get; set; }

[JsonPropertyName("groups")]
		public abstract bool Groups { get; set; }

[JsonPropertyName("broadcasts")]
		public abstract bool Broadcasts { get; set; }

[JsonPropertyName("bots")]
		public abstract bool Bots { get; set; }

[JsonPropertyName("exclude_muted")]
		public abstract bool ExcludeMuted { get; set; }

[JsonPropertyName("exclude_read")]
		public abstract bool ExcludeRead { get; set; }

[JsonPropertyName("exclude_archived")]
		public abstract bool ExcludeArchived { get; set; }

[JsonPropertyName("id")]
		public abstract int Id { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("emoticon")]
		public abstract string Emoticon { get; set; }

[JsonPropertyName("pinned_peers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

[JsonPropertyName("include_peers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

[JsonPropertyName("exclude_peers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
