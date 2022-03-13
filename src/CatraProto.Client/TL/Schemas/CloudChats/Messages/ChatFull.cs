using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatFull : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase
	{


        public static int StaticConstructorId { get => -438840932; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("full_chat")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase FullChat { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChatFull (CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase fullChat,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FullChat);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			FullChat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "messages.chatFull";
		}
	}
}