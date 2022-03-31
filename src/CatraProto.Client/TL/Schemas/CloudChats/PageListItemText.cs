using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListItemText : CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1188055347; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


        #nullable enable
 public PageListItemText (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
{
 Text = text;
 
}
#nullable disable
        internal PageListItemText() 
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
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
		
		public override string ToString()
		{
		    return "pageListItemText";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}