using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChat : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -124097970; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }


        #nullable enable
 public UpdateChat (long chatId)
{
 ChatId = chatId;
 
}
#nullable disable
        internal UpdateChat() 
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
			ChatId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "updateChat";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}