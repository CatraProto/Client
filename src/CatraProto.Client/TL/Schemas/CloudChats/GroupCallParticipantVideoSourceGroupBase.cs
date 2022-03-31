using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GroupCallParticipantVideoSourceGroupBase : IObject
    {

[Newtonsoft.Json.JsonProperty("semantics")]
		public abstract string Semantics { get; set; }

[Newtonsoft.Json.JsonProperty("sources")]
		public abstract IList<int> Sources { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
