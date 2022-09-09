using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SponsoredMessageBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("recommended")]
        public abstract bool Recommended { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public abstract byte[] RandomId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_id")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("chat_invite")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase ChatInvite { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("chat_invite_hash")]
        public abstract string ChatInviteHash { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_post")]
        public abstract int? ChannelPost { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("start_param")]
        public abstract string StartParam { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public abstract string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

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