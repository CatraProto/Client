using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureValueErrorBase : IObject
    {

[Newtonsoft.Json.JsonProperty("type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
