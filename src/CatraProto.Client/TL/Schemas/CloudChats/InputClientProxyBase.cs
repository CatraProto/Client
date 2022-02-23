using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputClientProxyBase : IObject
    {

[Newtonsoft.Json.JsonProperty("address")]
		public abstract string Address { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public abstract int Port { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
