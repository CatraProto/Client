using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageEntityBase : IObject
    {

[Newtonsoft.Json.JsonProperty("offset")]
		public abstract int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public abstract int Length { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
