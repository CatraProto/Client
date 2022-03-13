using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDocumentFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        public static int StaticConstructorId { get => -1160743548; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_size")]
		public string ThumbSize { get; set; }


        #nullable enable
 public InputDocumentFileLocation (long id,long accessHash,byte[] fileReference,string thumbSize)
{
 Id = id;
AccessHash = accessHash;
FileReference = fileReference;
ThumbSize = thumbSize;
 
}
#nullable disable
        internal InputDocumentFileLocation() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(FileReference);
			writer.Write(ThumbSize);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			ThumbSize = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputDocumentFileLocation";
		}
	}
}