using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class MessageContainerBase : IObject
    {

[Newtonsoft.Json.JsonProperty("messages")]
		public abstract IList<CatraProto.Client.TL.Schemas.MTProto.MessageBase> Messages { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
