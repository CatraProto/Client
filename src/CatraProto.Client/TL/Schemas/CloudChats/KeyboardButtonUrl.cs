using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrl : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        public static int StaticConstructorId { get => 629866245; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public override string Text { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			Url = reader.Read<string>();

		}
	}
}