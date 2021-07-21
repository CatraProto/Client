using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        public static int StaticConstructorId { get => -539317279; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("volume_id")]
		public long VolumeId { get; set; }

[JsonPropertyName("local_id")]
		public int LocalId { get; set; }

[JsonPropertyName("secret")]
		public long Secret { get; set; }

[JsonPropertyName("file_reference")]
		public byte[] FileReference { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}