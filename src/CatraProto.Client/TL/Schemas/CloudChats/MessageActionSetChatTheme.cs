using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSetChatTheme : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1434950843; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }


        #nullable enable
 public MessageActionSetChatTheme (string emoticon)
{
 Emoticon = emoticon;
 
}
#nullable disable
        internal MessageActionSetChatTheme() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messageActionSetChatTheme";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}