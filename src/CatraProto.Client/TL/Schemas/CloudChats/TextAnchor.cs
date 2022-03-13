using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextAnchor : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        public static int StaticConstructorId { get => 894777186; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("name")]
		public string Name { get; set; }


        #nullable enable
 public TextAnchor (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,string name)
{
 Text = text;
Name = name;
 
}
#nullable disable
        internal TextAnchor() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Name = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "textAnchor";
		}
	}
}