using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextPlain : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1950782688; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }


        #nullable enable
 public TextPlain (string text)
{
 Text = text;
 
}
#nullable disable
        internal TextPlain() 
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
		    return "textPlain";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}