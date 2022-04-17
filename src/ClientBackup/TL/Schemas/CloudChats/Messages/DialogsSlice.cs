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
	public partial class DialogsSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1910543603; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public int Count { get; set; }

[Newtonsoft.Json.JsonProperty("dialogs")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public DialogsSlice (int count,List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogs,List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Count = count;
Dialogs = dialogs;
Messages = messages;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal DialogsSlice() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Count);
var checkdialogs = 			writer.WriteVector(Dialogs, false);
if(checkdialogs.IsError){
 return checkdialogs; 
}
var checkmessages = 			writer.WriteVector(Messages, false);
if(checkmessages.IsError){
 return checkmessages; 
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
			var trycount = reader.ReadInt32();
if(trycount.IsError){
return ReadResult<IObject>.Move(trycount);
}
Count = trycount.Value;
			var trydialogs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trydialogs.IsError){
return ReadResult<IObject>.Move(trydialogs);
}
Dialogs = trydialogs.Value;
			var trymessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trymessages.IsError){
return ReadResult<IObject>.Move(trymessages);
}
Messages = trymessages.Value;
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
		    return "messages.dialogsSlice";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}