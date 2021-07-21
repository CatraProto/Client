using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class VotesListBase : IObject
    {

[JsonPropertyName("count")]
		public abstract int Count { get; set; }

[JsonPropertyName("votes")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase> Votes { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[JsonPropertyName("next_offset")]
		public abstract string NextOffset { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
