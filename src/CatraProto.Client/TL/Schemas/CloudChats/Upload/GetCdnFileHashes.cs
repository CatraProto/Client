using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetCdnFileHashes : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1302676017; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.FileHashBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("file_token")]
		public byte[] FileToken { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public int Offset { get; set; }

        
        #nullable enable
 public GetCdnFileHashes (byte[] fileToken,int offset)
{
 FileToken = fileToken;
Offset = offset;
 
}
#nullable disable
                
        internal GetCdnFileHashes() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			Offset = reader.Read<int>();

		}

		public override string ToString()
		{
		    return "upload.getCdnFileHashes";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}