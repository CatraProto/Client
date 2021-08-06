using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDocumentByHash : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 864953444; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.DocumentBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("sha256")]
		public byte[] Sha256 { get; set; }

[JsonPropertyName("size")]
		public int Size { get; set; }

[JsonPropertyName("mime_type")]
		public string MimeType { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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