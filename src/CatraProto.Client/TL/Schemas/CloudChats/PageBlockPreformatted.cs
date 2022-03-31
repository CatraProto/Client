using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPreformatted : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1066346178; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("language")]
		public string Language { get; set; }


        #nullable enable
 public PageBlockPreformatted (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,string language)
{
 Text = text;
Language = language;
 
}
#nullable disable
        internal PageBlockPreformatted() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Language);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Language = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "pageBlockPreformatted";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}