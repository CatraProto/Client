using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GroupCallParticipantVideoSourceGroupBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("semantics")]
        public abstract string Semantics { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public abstract List<int> Sources { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
