using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRangeBase : IObject
    {

[Newtonsoft.Json.JsonProperty("min_id")]
		public abstract int MinId { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public abstract int MaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
