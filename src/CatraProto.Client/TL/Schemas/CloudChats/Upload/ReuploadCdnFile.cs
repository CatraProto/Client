using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class ReuploadCdnFile : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1691921240; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.FileHashBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("file_token")]
		public byte[] FileToken { get; set; }

[Newtonsoft.Json.JsonProperty("request_token")]
		public byte[] RequestToken { get; set; }

        
        #nullable enable
 public ReuploadCdnFile (byte[] fileToken,byte[] requestToken)
{
 FileToken = fileToken;
RequestToken = requestToken;
 
}
#nullable disable
                
        internal ReuploadCdnFile() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FileToken);
			writer.Write(RequestToken);

		}

		public void Deserialize(Reader reader)
		{
			FileToken = reader.Read<byte[]>();
			RequestToken = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "upload.reuploadCdnFile";
		}
	}
}