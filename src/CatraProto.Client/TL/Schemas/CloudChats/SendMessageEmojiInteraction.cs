using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageEmojiInteraction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 630664139; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("interaction")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Interaction { get; set; }


        #nullable enable
 public SendMessageEmojiInteraction (string emoticon,int msgId,CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase interaction)
{
 Emoticon = emoticon;
MsgId = msgId;
Interaction = interaction;
 
}
#nullable disable
        internal SendMessageEmojiInteraction() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Emoticon);
			writer.Write(MsgId);
			writer.Write(Interaction);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();
			MsgId = reader.Read<int>();
			Interaction = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
		
		public override string ToString()
		{
		    return "sendMessageEmojiInteraction";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}