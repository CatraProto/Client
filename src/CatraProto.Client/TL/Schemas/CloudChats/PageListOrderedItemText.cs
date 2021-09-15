using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListOrderedItemText : CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase
	{


        public static int StaticConstructorId { get => 1577484359; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("num")]
		public override string Num { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Num = reader.Read<string>();
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
				
		public override string ToString()
		{
		    return "pageListOrderedItemText";
		}
	}
}