using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BankCardOpenUrlBase : IObject
    {

[JsonPropertyName("url")]
		public abstract string Url { get; set; }

[JsonPropertyName("name")]
		public abstract string Name { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
