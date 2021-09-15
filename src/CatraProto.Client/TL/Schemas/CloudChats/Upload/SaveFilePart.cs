using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class SaveFilePart : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1291540959; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("file_id")]
		public long FileId { get; set; }

[Newtonsoft.Json.JsonProperty("file_part")]
		public int FilePart { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
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
		
		public override string ToString()
		{
		    return "upload.saveFilePart";
		}
	}
}