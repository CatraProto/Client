using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChannelMigrateFrom : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -365344535; }
        
[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }


        #nullable enable
 public MessageActionChannelMigrateFrom (string title,long chatId)
{
 Title = title;
ChatId = chatId;
 
}
#nullable disable
        internal MessageActionChannelMigrateFrom() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
			ChatId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionChannelMigrateFrom";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}