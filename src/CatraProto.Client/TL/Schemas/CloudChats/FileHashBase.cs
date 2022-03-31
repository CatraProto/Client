using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FileHashBase : IObject
    {

[Newtonsoft.Json.JsonProperty("offset")]
		public abstract int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public abstract int Limit { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
