using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FileLocationToBeDeprecated : CatraProto.Client.TL.Schemas.CloudChats.FileLocationBase
	{


        public static int StaticConstructorId { get => -1132476723; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("volume_id")]
		public override long VolumeId { get; set; }

[Newtonsoft.Json.JsonProperty("local_id")]
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
				
		public override string ToString()
		{
		    return "fileLocationToBeDeprecated";
		}
	}
}