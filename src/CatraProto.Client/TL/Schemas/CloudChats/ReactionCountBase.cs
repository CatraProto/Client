using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ReactionCountBase : IObject
    {

[Newtonsoft.Json.JsonProperty("chosen")]
		public abstract bool Chosen { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public abstract string Reaction { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
