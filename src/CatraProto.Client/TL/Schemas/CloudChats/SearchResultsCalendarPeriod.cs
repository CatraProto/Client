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


        public static int StaticConstructorId { get => -911191137; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("min_msg_id")]
		public override int MinMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("max_msg_id")]
		public override int MaxMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public override int Count { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}