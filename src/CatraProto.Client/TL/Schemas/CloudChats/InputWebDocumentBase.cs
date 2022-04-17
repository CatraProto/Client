using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputWebDocumentBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("url")]
        public abstract string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public abstract int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public abstract string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("attributes")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
