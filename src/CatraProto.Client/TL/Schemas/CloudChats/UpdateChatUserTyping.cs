using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(FromId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();
			FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();

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