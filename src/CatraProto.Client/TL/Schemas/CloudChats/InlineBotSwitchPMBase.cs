using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InlineBotSwitchPMBase : IObject
    {

[Newtonsoft.Json.JsonProperty("text")]
		public abstract string Text { get; set; }

[Newtonsoft.Json.JsonProperty("start_param")]
		public abstract string StartParam { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
