using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ExportedMessageLinkBase : IObject
    {

[Newtonsoft.Json.JsonProperty("link")]
		public abstract string Link { get; set; }

[Newtonsoft.Json.JsonProperty("html")]
		public abstract string Html { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
