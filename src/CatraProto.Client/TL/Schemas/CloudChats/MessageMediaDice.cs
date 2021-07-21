using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaDice : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        public static int StaticConstructorId { get => 1065280907; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("value")]
		public int Value { get; set; }

[JsonPropertyName("emoticon")]
		public string Emoticon { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.Read<int>();
			Emoticon = reader.Read<string>();

		}
	}
}