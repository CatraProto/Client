using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateEncryptedMessagesRead : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 956179895; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

[JsonPropertyName("max_date")]
		public int MaxDate { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(MaxDate);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			MaxDate = reader.Read<int>();
			Date = reader.Read<int>();

		}
	}
}