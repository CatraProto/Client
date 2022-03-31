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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -290921362; }
        
[Newtonsoft.Json.JsonProperty("request_token")]
		public byte[] RequestToken { get; set; }


        #nullable enable
 public CdnFileReuploadNeeded (byte[] requestToken)
{
 RequestToken = requestToken;
 
}
#nullable disable
        internal CdnFileReuploadNeeded() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}