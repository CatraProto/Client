using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class TranslateResultText : CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase
	{


        public static int StaticConstructorId { get => -1575684144; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }


        #nullable enable
 public TranslateResultText (string text)
{
 Text = text;
 
}
#nullable disable
        internal TranslateResultText() 
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
		    return "messages.translateResultText";
		}
	}
}