using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputFileBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("parts")]
		public abstract int Parts { get; set; }

[JsonPropertyName("name")]
		public abstract string Name { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
