using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FileLocationToBeDeprecated : CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase
	{


        public static int StaticConstructorId { get => -1132476723; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("volume_id")]
		public override long VolumeId { get; set; }

[JsonPropertyName("local_id")]
		public override int LocalId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(VolumeId);
			writer.Write(LocalId);

		}

		public override void Deserialize(Reader reader)
		{
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();

		}
	}
}