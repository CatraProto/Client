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
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public string Type { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }


        #nullable enable
 public InputBotInlineResultPhoto (string id,string type,CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase photo,CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase sendMessage)
{
 Id = id;
Type = type;
Photo = photo;
SendMessage = sendMessage;
 
}
#nullable disable
        internal InputBotInlineResultPhoto() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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