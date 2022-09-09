using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageFwdHeaderBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("imported")]
        public abstract bool Imported { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_id")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_name")]
        public abstract string FromName { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public abstract int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_post")]
        public abstract int? ChannelPost { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("post_author")]
        public abstract string PostAuthor { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_from_peer")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase SavedFromPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("saved_from_msg_id")]
        public abstract int? SavedFromMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("psa_type")]
        public abstract string PsaType { get; set; }

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