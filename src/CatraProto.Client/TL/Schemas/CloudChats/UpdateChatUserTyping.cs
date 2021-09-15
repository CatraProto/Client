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


        public static int StaticConstructorId { get => -1704596961; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public int ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase Action { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<int>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase>();

		}
				
		public override string ToString()
		{
		    return "updateChatUserTyping";
		}
	}
}