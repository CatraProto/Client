using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatPhoto : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -900957736; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

[JsonPropertyName("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase Photo { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(Photo);

		}

		public void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase>();

		}
	}
}