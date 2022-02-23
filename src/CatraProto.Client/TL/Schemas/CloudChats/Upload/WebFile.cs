using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class WebFile : CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase
    {
        public static int StaticConstructorId
        {
            get => 568808380;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("size")] public sealed override int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public sealed override string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("file_type")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase FileType { get; set; }

        [Newtonsoft.Json.JsonProperty("mtime")]
        public sealed override int Mtime { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override byte[] Bytes { get; set; }


    #nullable enable
        public WebFile(int size, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase fileType, int mtime, byte[] bytes)
        {
            Size = size;
            MimeType = mimeType;
            FileType = fileType;
            Mtime = mtime;
            Bytes = bytes;
        }
    #nullable disable
        internal WebFile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Size);
            writer.Write(MimeType);
            writer.Write(FileType);
            writer.Write(Mtime);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Size = reader.Read<int>();
            MimeType = reader.Read<string>();
            FileType = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase>();
            Mtime = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "upload.webFile";
        }
    }
}