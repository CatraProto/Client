using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class SaveBigFilePart : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -562337987; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("file_id")]
		public long FileId { get; set; }

[JsonPropertyName("file_part")]
		public int FilePart { get; set; }

[JsonPropertyName("file_total_parts")]
		public int FileTotalParts { get; set; }

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
			writer.Write(FileTotalParts);
			writer.Write(Bytes);

		}

		public void Deserialize(Reader reader)
		{
			FileId = reader.Read<long>();
			FilePart = reader.Read<int>();
			FileTotalParts = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}