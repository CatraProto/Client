using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWebFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase
	{


        public static int StaticConstructorId { get => -1036396922; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public override long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputWebFileLocation";
		}
	}
}