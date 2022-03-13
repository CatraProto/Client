using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        public static int StaticConstructorId { get => -539317279; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("volume_id")]
		public long VolumeId { get; set; }

[Newtonsoft.Json.JsonProperty("local_id")]
		public int LocalId { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public long Secret { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }


        #nullable enable
 public InputFileLocation (long volumeId,int localId,long secret,byte[] fileReference)
{
 VolumeId = volumeId;
LocalId = localId;
Secret = secret;
FileReference = fileReference;
 
}
#nullable disable
        internal InputFileLocation() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(VolumeId);
			writer.Write(LocalId);
			writer.Write(Secret);
			writer.Write(FileReference);

		}

		public override void Deserialize(Reader reader)
		{
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();
			Secret = reader.Read<long>();
			FileReference = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "inputFileLocation";
		}
	}
}