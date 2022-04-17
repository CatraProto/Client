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
	public partial class MessageActionInviteToGroupCall : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1345295095; }
        
[Newtonsoft.Json.JsonProperty("call")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public List<long> Users { get; set; }


        #nullable enable
 public MessageActionInviteToGroupCall (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call,List<long> users)
{
 Call = call;
Users = users;
 
}
#nullable disable
        internal MessageActionInviteToGroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkcall = 			writer.WriteObject(Call);
if(checkcall.IsError){
 return checkcall; 
}

			writer.WriteVector(Users, false);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
if(trycall.IsError){
return ReadResult<IObject>.Move(trycall);
}
Call = trycall.Value;
			var tryusers = reader.ReadVector<long>(ParserTypes.Int64);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messageActionInviteToGroupCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}