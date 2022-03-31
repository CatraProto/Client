using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextUnderline : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1054465340; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


        #nullable enable
 public TextUnderline (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
{
 Text = text;
 
}
#nullable disable
        internal TextUnderline() 
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
		    return "textUnderline";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}