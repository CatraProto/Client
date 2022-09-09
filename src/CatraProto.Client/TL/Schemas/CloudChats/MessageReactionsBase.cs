using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageReactionsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("min")] public abstract bool Min { get; set; }

        [Newtonsoft.Json.JsonProperty("can_see_list")]
        public abstract bool CanSeeList { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> Results { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recent_reactions")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> RecentReactions { get; set; }

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