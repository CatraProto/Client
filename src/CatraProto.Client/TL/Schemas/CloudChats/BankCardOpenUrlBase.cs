using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BankCardOpenUrlBase : IObject
    {

[Newtonsoft.Json.JsonProperty("url")]
		public abstract string Url { get; set; }

[Newtonsoft.Json.JsonProperty("name")]
		public abstract string Name { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
