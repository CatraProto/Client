using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultGame : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1336154098; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


        #nullable enable
 public InputBotInlineResultGame (string id,string shortName,CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
{
 Id = id;
ShortName = shortName;
SendMessage = sendMessage;
 
}
#nullable disable
        internal InputBotInlineResultGame() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(ShortName);
			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			ShortName = reader.Read<string>();
			SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();

		}
		
		public override string ToString()
		{
		    return "inputBotInlineResultGame";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}