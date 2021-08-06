using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class SaveFilePart : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1291540959; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("file_id")]
		public long FileId { get; set; }

[JsonPropertyName("file_part")]
		public int FilePart { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileId);
			writer.Write(FilePart);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			FileId = reader.Read<long>();
			FilePart = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}