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
	public partial class Dialogs : CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 364538944; }
        
[Newtonsoft.Json.JsonProperty("dialogs")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> DialogsField { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public Dialogs (List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogsField,List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 DialogsField = dialogsField;
Messages = messages;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal Dialogs() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkdialogsField = 			writer.WriteVector(DialogsField, false);
if(checkdialogsField.IsError){
 return checkdialogsField; 
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
			var trydialogsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trydialogsField.IsError){
return ReadResult<IObject>.Move(trydialogsField);
}
DialogsField = trydialogsField.Value;
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
		    return "messages.dialogs";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}