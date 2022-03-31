using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsDateRangeDays : CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1237848657; }
        
[Newtonsoft.Json.JsonProperty("min_date")]
		public sealed override int MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("max_date")]
		public sealed override int MaxDate { get; set; }


        #nullable enable
 public StatsDateRangeDays (int minDate,int maxDate)
{
 MinDate = minDate;
MaxDate = maxDate;
 
}
#nullable disable
        internal StatsDateRangeDays() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(MinDate);
			writer.Write(MaxDate);

		}

		public override void Deserialize(Reader reader)
		{
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "statsDateRangeDays";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}