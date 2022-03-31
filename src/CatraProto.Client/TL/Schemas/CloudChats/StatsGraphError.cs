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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1092839390; }
        
[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }


        #nullable enable
 public StatsGraphError (string error)
{
 Error = error;
 
}
#nullable disable
        internal StatsGraphError() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}