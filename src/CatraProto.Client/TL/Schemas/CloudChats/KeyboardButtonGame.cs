using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonGame : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        public static int StaticConstructorId { get => 1358175439; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public KeyboardButtonGame (string text)
{
 Text = text;
 
}
#nullable disable
        internal KeyboardButtonGame() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "keyboardButtonGame";
		}
	}
}