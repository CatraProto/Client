using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SearchResultsCalendarPeriod : CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -911191137; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("min_msg_id")]
		public sealed override int MinMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("max_msg_id")]
		public sealed override int MaxMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }


        #nullable enable
 public SearchResultsCalendarPeriod (int date,int minMsgId,int maxMsgId,int count)
{
 Date = date;
MinMsgId = minMsgId;
MaxMsgId = maxMsgId;
Count = count;
 
}
#nullable disable
        internal SearchResultsCalendarPeriod() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Date);
			writer.Write(MinMsgId);
			writer.Write(MaxMsgId);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			MinMsgId = reader.Read<int>();
			MaxMsgId = reader.Read<int>();
			Count = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "searchResultsCalendarPeriod";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}