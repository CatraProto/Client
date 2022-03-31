using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextPhone : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 483104362; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public string Phone { get; set; }


        #nullable enable
 public TextPhone (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,string phone)
{
 Text = text;
Phone = phone;
 
}
#nullable disable
        internal TextPhone() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Phone = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "textPhone";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}