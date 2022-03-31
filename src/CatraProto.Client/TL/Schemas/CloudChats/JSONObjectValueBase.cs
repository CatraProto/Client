using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class JSONObjectValueBase : IObject
    {

[Newtonsoft.Json.JsonProperty("key")]
		public abstract string Key { get; set; }

[Newtonsoft.Json.JsonProperty("value")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
