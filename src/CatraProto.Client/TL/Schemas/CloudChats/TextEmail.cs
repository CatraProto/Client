using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextEmail : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        public static int StaticConstructorId { get => -564523562; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("email")]
		public string Email { get; set; }


        #nullable enable
 public TextEmail (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,string email)
{
 Text = text;
Email = email;
 
}
#nullable disable
        internal TextEmail() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Email);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Email = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "textEmail";
		}
	}
}