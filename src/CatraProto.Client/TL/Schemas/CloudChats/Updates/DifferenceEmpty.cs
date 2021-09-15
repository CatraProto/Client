using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceEmpty : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
	{


        public static int StaticConstructorId { get => 1567990072; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("seq")]
		public int Seq { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Date);
			writer.Write(Seq);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			Seq = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updates.differenceEmpty";
		}
	}
}