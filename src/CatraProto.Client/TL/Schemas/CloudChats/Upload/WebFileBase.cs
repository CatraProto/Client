using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public abstract class WebFileBase : IObject
    {

[Newtonsoft.Json.JsonProperty("size")]
		public abstract int Size { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public abstract string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("file_type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase FileType { get; set; }

[Newtonsoft.Json.JsonProperty("mtime")]
		public abstract int Mtime { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
