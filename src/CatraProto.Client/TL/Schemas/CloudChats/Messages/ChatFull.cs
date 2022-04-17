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
	public partial class ChatFull : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -438840932; }
        
[Newtonsoft.Json.JsonProperty("full_chat")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase FullChat { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChatFull (CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase fullChat,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 FullChat = fullChat;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal ChatFull() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkfullChat = 			writer.WriteObject(FullChat);
if(checkfullChat.IsError){
 return checkfullChat; 
}
var checkchats = 			writer.WriteVector(Chats, false);
if(checkchats.IsError){
 return checkchats; 
}
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryfullChat = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase>();
if(tryfullChat.IsError){
return ReadResult<IObject>.Move(tryfullChat);
}
FullChat = tryfullChat.Value;
			var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trychats.IsError){
return ReadResult<IObject>.Move(trychats);
}
Chats = trychats.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.chatFull";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}