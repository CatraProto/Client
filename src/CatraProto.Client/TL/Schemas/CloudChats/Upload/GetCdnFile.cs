using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetCdnFile : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 536919235; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("file_token")]
		public byte[] FileToken { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "upload.getCdnFile";
		}
	}
}