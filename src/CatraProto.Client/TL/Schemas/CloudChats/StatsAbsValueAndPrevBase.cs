using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsAbsValueAndPrevBase : IObject
    {

[Newtonsoft.Json.JsonProperty("current")]
		public abstract double Current { get; set; }

[Newtonsoft.Json.JsonProperty("previous")]
		public abstract double Previous { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
