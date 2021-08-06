using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class SentEmailCodeBase : IObject
    {

[JsonPropertyName("email_pattern")]
		public abstract string EmailPattern { get; set; }

[JsonPropertyName("length")]
		public abstract int Length { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
