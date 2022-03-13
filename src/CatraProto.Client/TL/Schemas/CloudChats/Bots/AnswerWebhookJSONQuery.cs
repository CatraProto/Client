using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class AnswerWebhookJSONQuery : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -434028723; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }

        
        #nullable enable
 public AnswerWebhookJSONQuery (long queryId,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
{
 QueryId = queryId;
Data = data;
 
}
#nullable disable
                
        internal AnswerWebhookJSONQuery() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(QueryId);
			writer.Write(Data);

		}

		public void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "bots.answerWebhookJSONQuery";
		}
	}
}