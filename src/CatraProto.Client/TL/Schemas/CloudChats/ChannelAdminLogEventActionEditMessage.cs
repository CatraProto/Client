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
	public partial class ChannelAdminLogEventActionEditMessage : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1889215493; }
        
[Newtonsoft.Json.JsonProperty("prev_message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase PrevMessage { get; set; }

[Newtonsoft.Json.JsonProperty("new_message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase NewMessage { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionEditMessage (CatraProto.Client.TL.Schemas.CloudChats.MessageBase prevMessage,CatraProto.Client.TL.Schemas.CloudChats.MessageBase newMessage)
{
 PrevMessage = prevMessage;
NewMessage = newMessage;
 
}
#nullable disable
        internal ChannelAdminLogEventActionEditMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkprevMessage = 			writer.WriteObject(PrevMessage);
if(checkprevMessage.IsError){
 return checkprevMessage; 
}
var checknewMessage = 			writer.WriteObject(NewMessage);
if(checknewMessage.IsError){
 return checknewMessage; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryprevMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
if(tryprevMessage.IsError){
return ReadResult<IObject>.Move(tryprevMessage);
}
PrevMessage = tryprevMessage.Value;
			var trynewMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
if(trynewMessage.IsError){
return ReadResult<IObject>.Move(trynewMessage);
}
NewMessage = trynewMessage.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionEditMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}