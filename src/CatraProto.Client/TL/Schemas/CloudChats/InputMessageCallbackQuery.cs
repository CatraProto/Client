using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessageCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1392895362; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }


        #nullable enable
 public InputMessageCallbackQuery (int id,long queryId)
{
 Id = id;
QueryId = queryId;
 
}
#nullable disable
        internal InputMessageCallbackQuery() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(QueryId);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			QueryId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "inputMessageCallbackQuery";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}