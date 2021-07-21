using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetDice : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        public static int StaticConstructorId { get => -427863538; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("emoticon")]
		public string Emoticon { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();

		}
	}
}