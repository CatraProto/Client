using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
	{


        public static int StaticConstructorId { get => -1462213465; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public string Type { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Type);
			writer.Write(Photo);
			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
			SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();

		}
				
		public override string ToString()
		{
		    return "inputBotInlineResultPhoto";
		}
	}
}