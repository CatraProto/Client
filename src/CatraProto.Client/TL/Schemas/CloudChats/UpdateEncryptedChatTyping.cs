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


        public static int StaticConstructorId { get => 386986326; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public int ChatId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}