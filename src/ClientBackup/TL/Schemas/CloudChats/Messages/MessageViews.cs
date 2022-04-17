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
	public partial class MessageViews : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1228606141; }
        
[Newtonsoft.Json.JsonProperty("views")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase> Views { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public MessageViews (List<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase> views,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Views = views;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal MessageViews() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkviews = 			writer.WriteVector(Views, false);
if(checkviews.IsError){
 return checkviews; 
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
			var tryviews = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryviews.IsError){
return ReadResult<IObject>.Move(tryviews);
}
Views = tryviews.Value;
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
		    return "messages.messageViews";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}