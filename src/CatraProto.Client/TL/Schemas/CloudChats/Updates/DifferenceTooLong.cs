using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class DifferenceTooLong : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
	{


        public static int StaticConstructorId { get => 1258196845; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updates.differenceTooLong";
		}
	}
}