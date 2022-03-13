using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageCaption : CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase
	{


        public static int StaticConstructorId { get => 1869903447; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("credit")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Credit { get; set; }


        #nullable enable
 public PageCaption (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,CatraProto.Client.TL.Schemas.CloudChats.RichTextBase credit)
{
 Text = text;
Credit = credit;
 
}
#nullable disable
        internal PageCaption() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Credit);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Credit = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
				
		public override string ToString()
		{
		    return "pageCaption";
		}
	}
}