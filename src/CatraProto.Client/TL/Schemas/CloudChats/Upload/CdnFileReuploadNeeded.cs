using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFileReuploadNeeded : CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase
	{


        public static int StaticConstructorId { get => -290921362; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("request_token")]
		public byte[] RequestToken { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(RequestToken);

		}

		public override void Deserialize(Reader reader)
		{
			RequestToken = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "upload.cdnFileReuploadNeeded";
		}
	}
}