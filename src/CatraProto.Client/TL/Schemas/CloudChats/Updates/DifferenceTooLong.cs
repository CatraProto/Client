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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1258196845; }
        
[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }


        #nullable enable
 public DifferenceTooLong (int pts)
{
 Pts = pts;
 
}
#nullable disable
        internal DifferenceTooLong() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}