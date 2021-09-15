using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneConnectionBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public abstract string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("ipv6")]
		public abstract string Ipv6 { get; set; }

[Newtonsoft.Json.JsonProperty("port")]
		public abstract int Port { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
