using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class CdnFile : CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase
	{


        public static int StaticConstructorId { get => -1449145777; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("bytes")]
		public byte[] Bytes { get; set; }


        #nullable enable
 public CdnFile (byte[] bytes)
{
 Bytes = bytes;
 
}
#nullable disable
        internal CdnFile() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Bytes = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "upload.cdnFile";
		}
	}
}