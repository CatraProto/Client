using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDocumentByHash : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 864953444;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.DocumentBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("sha256")]
        public byte[] Sha256 { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }


    #nullable enable
        public GetDocumentByHash(byte[] sha256, int size, string mimeType)
        {
            Sha256 = sha256;
            Size = size;
            MimeType = mimeType;
        }
    #nullable disable

        internal GetDocumentByHash()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Sha256);
            writer.Write(Size);
            writer.Write(MimeType);
        }

        public void Deserialize(Reader reader)
        {
            Sha256 = reader.Read<byte[]>();
            Size = reader.Read<int>();
            MimeType = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messages.getDocumentByHash";
        }
    }
}