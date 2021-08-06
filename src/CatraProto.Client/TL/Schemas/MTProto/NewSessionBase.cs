using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class NewSessionBase : IObject
    {

[JsonPropertyName("first_msg_id")]
		public abstract long FirstMsgId { get; set; }

[JsonPropertyName("unique_id")]
		public abstract long UniqueId { get; set; }

[JsonPropertyName("server_salt")]
		public abstract long ServerSalt { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
