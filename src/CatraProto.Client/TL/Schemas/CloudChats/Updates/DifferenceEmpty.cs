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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1567990072; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("seq")]
		public int Seq { get; set; }


        #nullable enable
 public DifferenceEmpty (int date,int seq)
{
 Date = date;
Seq = seq;
 
}
#nullable disable
        internal DifferenceEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}