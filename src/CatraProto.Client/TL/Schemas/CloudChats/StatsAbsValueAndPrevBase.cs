using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsAbsValueAndPrevBase : IObject
    {

[JsonPropertyName("current")]
		public abstract double Current { get; set; }

[JsonPropertyName("previous")]
		public abstract double Previous { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
