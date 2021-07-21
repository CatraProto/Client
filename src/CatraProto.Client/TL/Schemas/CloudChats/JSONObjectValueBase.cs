using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class JSONObjectValueBase : IObject
    {

[JsonPropertyName("key")]
		public abstract string Key { get; set; }

[JsonPropertyName("value")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
