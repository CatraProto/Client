using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MessageCopyBase : IObject
    {

[Newtonsoft.Json.JsonProperty("orig_message")]
		public abstract CatraProto.Client.TL.Schemas.MTProto.MessageBase OrigMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
