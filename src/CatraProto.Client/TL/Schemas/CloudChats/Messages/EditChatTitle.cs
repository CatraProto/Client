using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatTitle : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1937260541; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

        
        #nullable enable
 public EditChatTitle (long chatId,string title)
{
 ChatId = chatId;
Title = title;
 
}
#nullable disable
                
        internal EditChatTitle() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Title);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();
			Title = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messages.editChatTitle";
		}
	}
}