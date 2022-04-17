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
	public partial class UpdateChatUserTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2092401936; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("from_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }


        #nullable enable
 public UpdateChatUserTyping (long chatId,CatraProto.Client.TL.Schemas.CloudChats.PeerBase fromId,CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action)
{
 ChatId = chatId;
FromId = fromId;
Action = action;
 
}
#nullable disable
        internal UpdateChatUserTyping() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(ChatId);
var checkfromId = 			writer.WriteObject(FromId);
if(checkfromId.IsError){
 return checkfromId; 
}
var checkaction = 			writer.WriteObject(Action);
if(checkaction.IsError){
 return checkaction; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychatId = reader.ReadInt64();
if(trychatId.IsError){
return ReadResult<IObject>.Move(trychatId);
}
ChatId = trychatId.Value;
			var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(tryfromId.IsError){
return ReadResult<IObject>.Move(tryfromId);
}
FromId = tryfromId.Value;
			var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();
if(tryaction.IsError){
return ReadResult<IObject>.Move(tryaction);
}
Action = tryaction.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateChatUserTyping";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}