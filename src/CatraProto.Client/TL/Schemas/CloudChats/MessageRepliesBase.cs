using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRepliesBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("comments")]
        public abstract bool Comments { get; set; }

        [Newtonsoft.Json.JsonProperty("replies")]
        public abstract int Replies { get; set; }

        [Newtonsoft.Json.JsonProperty("replies_pts")]
        public abstract int RepliesPts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recent_repliers")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public abstract long? ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public abstract int? MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public abstract int? ReadMaxId { get; set; }

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