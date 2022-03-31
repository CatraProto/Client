using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebDocumentBase : IObject
    {

[Newtonsoft.Json.JsonProperty("url")]
		public abstract string Url { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public abstract int Size { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public abstract string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("attributes")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
