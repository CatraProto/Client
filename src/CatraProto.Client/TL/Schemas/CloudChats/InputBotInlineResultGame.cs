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


        public static int StaticConstructorId { get => 1336154098; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}