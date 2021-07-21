using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class ReuploadCdnFile : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1691921240; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.FileHashBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("file_token")]
		public byte[] FileToken { get; set; }

[JsonPropertyName("request_token")]
		public byte[] RequestToken { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(RequestToken);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			RequestToken = reader.Read<byte[]>();

		}
	}
}