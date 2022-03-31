using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotWebhookJSONQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1684914010; }
        
[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public int Timeout { get; set; }


        #nullable enable
 public UpdateBotWebhookJSONQuery (long queryId,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data,int timeout)
{
 QueryId = queryId;
Data = data;
Timeout = timeout;
 
}
#nullable disable
        internal UpdateBotWebhookJSONQuery() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(QueryId);
			writer.Write(Data);
			writer.Write(Timeout);

		}

		public override void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			Timeout = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateBotWebhookJSONQuery";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}