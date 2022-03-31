using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageReactionsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("min")]
		public abstract bool Min { get; set; }

[Newtonsoft.Json.JsonProperty("can_see_list")]
		public abstract bool CanSeeList { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ReactionCountBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("recent_reactions")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> RecentReactions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
