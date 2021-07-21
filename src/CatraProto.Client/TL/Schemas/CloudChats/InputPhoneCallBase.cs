using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputPhoneCallBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("access_hash")]
		public abstract long AccessHash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
