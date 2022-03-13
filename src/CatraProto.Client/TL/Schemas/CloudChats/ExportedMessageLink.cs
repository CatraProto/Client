using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ExportedMessageLink : CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase
	{


        public static int StaticConstructorId { get => 1571494644; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("link")]
		public sealed override string Link { get; set; }

[Newtonsoft.Json.JsonProperty("html")]
		public sealed override string Html { get; set; }


        #nullable enable
 public ExportedMessageLink (string link,string html)
{
 Link = link;
Html = html;
 
}
#nullable disable
        internal ExportedMessageLink() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Link);
			writer.Write(Html);

		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();
			Html = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "exportedMessageLink";
		}
	}
}