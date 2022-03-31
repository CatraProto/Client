using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsDateRangeDaysBase : IObject
    {

[Newtonsoft.Json.JsonProperty("min_date")]
		public abstract int MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("max_date")]
		public abstract int MaxDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
