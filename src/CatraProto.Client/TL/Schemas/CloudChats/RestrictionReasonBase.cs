using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class RestrictionReasonBase : IObject
    {

[Newtonsoft.Json.JsonProperty("platform")]
		public abstract string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public abstract string Reason { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
