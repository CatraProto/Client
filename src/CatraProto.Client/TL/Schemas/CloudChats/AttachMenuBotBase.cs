using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AttachMenuBotBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("inactive")]
        public abstract bool Inactive { get; set; }

        [Newtonsoft.Json.JsonProperty("has_settings")]
        public abstract bool HasSettings { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public abstract long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public abstract string ShortName { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_types")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuPeerTypeBase> PeerTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("icons")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotIconBase> Icons { get; set; }

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