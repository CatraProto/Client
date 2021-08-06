using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterSuggestedBase : IObject
    {

[JsonPropertyName("filter")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

[JsonPropertyName("description")]
		public abstract string Description { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
