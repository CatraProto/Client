using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhotoLegacyFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        public static int StaticConstructorId { get => -667654413; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }

[Newtonsoft.Json.JsonProperty("volume_id")]
		public long VolumeId { get; set; }

[Newtonsoft.Json.JsonProperty("local_id")]
		public int LocalId { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public long Secret { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(FileReference);
			writer.Write(VolumeId);
			writer.Write(LocalId);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();
			Secret = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputPhotoLegacyFileLocation";
		}
	}
}