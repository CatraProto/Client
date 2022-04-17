using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(QueryId);
var checkdata = 			writer.WriteObject(Data);
if(checkdata.IsError){
 return checkdata; 
}
writer.WriteInt32(Timeout);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryqueryId = reader.ReadInt64();
if(tryqueryId.IsError){
return ReadResult<IObject>.Move(tryqueryId);
}
QueryId = tryqueryId.Value;
			var trydata = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
if(trydata.IsError){
return ReadResult<IObject>.Move(trydata);
}
Data = trydata.Value;
			var trytimeout = reader.ReadInt32();
if(trytimeout.IsError){
return ReadResult<IObject>.Move(trytimeout);
}
Timeout = trytimeout.Value;
return new ReadResult<IObject>(this);

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