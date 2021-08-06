using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class EncryptedMessageBase : IObject
    {

[JsonPropertyName("random_id")]
		public abstract long RandomId { get; set; }

[JsonPropertyName("chat_id")]
		public abstract int ChatId { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("bytes")]
		public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
