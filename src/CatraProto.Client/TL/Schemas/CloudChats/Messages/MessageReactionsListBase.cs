using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class MessageReactionsListBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("count")]
        public abstract int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("reactions")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> Reactions { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_offset")]
        public abstract string NextOffset { get; set; }

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