using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("contacts")]
        public abstract bool Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("non_contacts")]
        public abstract bool NonContacts { get; set; }

        [Newtonsoft.Json.JsonProperty("groups")]
        public abstract bool Groups { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcasts")]
        public abstract bool Broadcasts { get; set; }

        [Newtonsoft.Json.JsonProperty("bots")]
        public abstract bool Bots { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_muted")]
        public abstract bool ExcludeMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_read")]
        public abstract bool ExcludeRead { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_archived")]
        public abstract bool ExcludeArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("emoticon")]
        public abstract string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> PinnedPeers { get; set; }

        [Newtonsoft.Json.JsonProperty("include_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> IncludePeers { get; set; }

        [Newtonsoft.Json.JsonProperty("exclude_peers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ExcludePeers { get; set; }

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
