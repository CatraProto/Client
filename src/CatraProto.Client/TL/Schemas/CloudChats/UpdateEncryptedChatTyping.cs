using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateEncryptedChatTyping : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 386986326; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public int ChatId { get; set; }


        #nullable enable
 public UpdateEncryptedChatTyping (int chatId)
{
 ChatId = chatId;
 
}
#nullable disable
        internal UpdateEncryptedChatTyping() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateEncryptedChatTyping";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}