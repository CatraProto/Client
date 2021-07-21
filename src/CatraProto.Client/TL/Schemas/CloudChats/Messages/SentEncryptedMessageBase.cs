using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class SentEncryptedMessageBase : IObject
    {

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
