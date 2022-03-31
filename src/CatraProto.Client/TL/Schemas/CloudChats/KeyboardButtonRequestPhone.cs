using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class KeyboardButtonRequestPhone : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1318425559; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public KeyboardButtonRequestPhone (string text)
{
 Text = text;
 
}
#nullable disable
        internal KeyboardButtonRequestPhone() 
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
		    return "keyboardButtonRequestPhone";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}