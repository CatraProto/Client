using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class SaveBigFilePart : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -562337987; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("file_id")]
		public long FileId { get; set; }

[Newtonsoft.Json.JsonProperty("file_part")]
		public int FilePart { get; set; }

[Newtonsoft.Json.JsonProperty("file_total_parts")]
		public int FileTotalParts { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public byte[] Bytes { get; set; }

        
        #nullable enable
 public SaveBigFilePart (long fileId,int filePart,int fileTotalParts,byte[] bytes)
{
 FileId = fileId;
FilePart = filePart;
FileTotalParts = fileTotalParts;
Bytes = bytes;
 
}
#nullable disable
                
        internal SaveBigFilePart() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override string ToString()
		{
		    return "upload.saveBigFilePart";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}