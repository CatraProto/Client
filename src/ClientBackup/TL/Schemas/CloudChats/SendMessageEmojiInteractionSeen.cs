using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageEmojiInteractionSeen : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1234857938; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }


        #nullable enable
 public SendMessageEmojiInteractionSeen (string emoticon)
{
 Emoticon = emoticon;
 
}
#nullable disable
        internal SendMessageEmojiInteractionSeen() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteString(Emoticon);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryemoticon = reader.ReadString();
if(tryemoticon.IsError){
return ReadResult<IObject>.Move(tryemoticon);
}
Emoticon = tryemoticon.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "sendMessageEmojiInteractionSeen";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}