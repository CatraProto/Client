using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public abstract class WebFileBase : IObject
    {

[JsonPropertyName("size")]
		public abstract int Size { get; set; }

[JsonPropertyName("mime_type")]
		public abstract string MimeType { get; set; }

[JsonPropertyName("file_type")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase FileType { get; set; }

[JsonPropertyName("mtime")]
		public abstract int Mtime { get; set; }

[JsonPropertyName("bytes")]
		public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
