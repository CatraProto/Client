using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDocumentByHash : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 864953444;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DocumentBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("sha256")] public byte[] Sha256 { get; set; }

        [JsonProperty("size")] public int Size { get; set; }

        [JsonProperty("mime_type")] public string MimeType { get; set; }

        public override string ToString()
        {
            return "messages.getDocumentByHash";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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
    }
}