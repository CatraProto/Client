using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ErrorBase : IObject
    {

[Newtonsoft.Json.JsonProperty("code")]
		public abstract int Code { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
