using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Report : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1991005362; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public List<int> Id { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase Reason { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

        
        #nullable enable
 public Report (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,List<int> id,CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason,string message)
{
 Peer = peer;
Id = id;
Reason = reason;
Message = message;
 
}
#nullable disable
                
        internal Report() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}

			writer.WriteVector(Id, false);
var checkreason = 			writer.WriteObject(Reason);
if(checkreason.IsError){
 return checkreason; 
}

			writer.WriteString(Message);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var tryid = reader.ReadVector<int>(ParserTypes.Int);
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase>();
if(tryreason.IsError){
return ReadResult<IObject>.Move(tryreason);
}
Reason = tryreason.Value;
			var trymessage = reader.ReadString();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.report";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}