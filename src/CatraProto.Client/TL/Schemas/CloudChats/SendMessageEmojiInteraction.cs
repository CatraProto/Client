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


        public static int StaticConstructorId { get => 630664139; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("interaction")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Interaction { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}