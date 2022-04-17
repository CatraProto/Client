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
	public partial class EditChatTitle : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1937260541; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(ChatId);

			writer.WriteString(Title);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychatId = reader.ReadInt64();
if(trychatId.IsError){
return ReadResult<IObject>.Move(trychatId);
}
ChatId = trychatId.Value;
			var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.editChatTitle";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}