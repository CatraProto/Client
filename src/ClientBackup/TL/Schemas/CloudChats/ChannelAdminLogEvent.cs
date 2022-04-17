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
	public partial class ChannelAdminLogEvent : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 531458253; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }


        #nullable enable
 public ChannelAdminLogEvent (long id,int date,long userId,CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase action)
{
 Id = id;
Date = date;
UserId = userId;
Action = action;
 
}
#nullable disable
        internal ChannelAdminLogEvent() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(Id);
writer.WriteInt32(Date);
writer.WriteInt64(UserId);
var checkaction = 			writer.WriteObject(Action);
if(checkaction.IsError){
 return checkaction; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryid = reader.ReadInt64();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
			var tryuserId = reader.ReadInt64();
if(tryuserId.IsError){
return ReadResult<IObject>.Move(tryuserId);
}
UserId = tryuserId.Value;
			var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase>();
if(tryaction.IsError){
return ReadResult<IObject>.Move(tryaction);
}
Action = tryaction.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEvent";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}