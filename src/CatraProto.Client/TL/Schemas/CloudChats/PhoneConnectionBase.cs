using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneConnectionBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("ip")]
		public abstract string Ip { get; set; }

[JsonPropertyName("ipv6")]
		public abstract string Ipv6 { get; set; }

[JsonPropertyName("port")]
		public abstract int Port { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
