using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsGraphError : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
	{


        public static int StaticConstructorId { get => -1092839390; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Error);

		}

		public override void Deserialize(Reader reader)
		{
			Error = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "statsGraphError";
		}
	}
}