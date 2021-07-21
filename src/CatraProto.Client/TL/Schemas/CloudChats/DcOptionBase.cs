using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DcOptionBase : IObject
    {

[JsonPropertyName("ipv6")]
		public abstract bool Ipv6 { get; set; }

[JsonPropertyName("media_only")]
		public abstract bool MediaOnly { get; set; }

[JsonPropertyName("tcpo_only")]
		public abstract bool TcpoOnly { get; set; }

[JsonPropertyName("cdn")]
		public abstract bool Cdn { get; set; }

[JsonPropertyName("static")]
		public abstract bool Static { get; set; }

[JsonPropertyName("id")]
		public abstract int Id { get; set; }

[JsonPropertyName("ip_address")]
		public abstract string IpAddress { get; set; }

[JsonPropertyName("port")]
		public abstract int Port { get; set; }

[JsonPropertyName("secret")]
		public abstract byte[] Secret { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
