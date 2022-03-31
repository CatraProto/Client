using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class AffectedFoundMessagesBase : IObject
    {

[Newtonsoft.Json.JsonProperty("pts")]
		public abstract int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public abstract int PtsCount { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public abstract int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public abstract IList<int> Messages { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
