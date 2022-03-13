using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TextUrl : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
	{


        public static int StaticConstructorId { get => 1009288385; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("webpage_id")]
		public long WebpageId { get; set; }


        #nullable enable
 public TextUrl (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,string url,long webpageId)
{
 Text = text;
Url = url;
WebpageId = webpageId;
 
}
#nullable disable
        internal TextUrl() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Url);
			writer.Write(WebpageId);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Url = reader.Read<string>();
			WebpageId = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "textUrl";
		}
	}
}