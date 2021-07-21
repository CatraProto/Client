using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRequestPhone : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        public static int StaticConstructorId { get => -1318425559; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();

		}
	}
}