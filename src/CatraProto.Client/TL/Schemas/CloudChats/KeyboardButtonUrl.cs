using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonUrl : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        public static int StaticConstructorId { get => 629866245; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
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
				
		public override string ToString()
		{
		    return "keyboardButtonUrl";
		}
	}
}