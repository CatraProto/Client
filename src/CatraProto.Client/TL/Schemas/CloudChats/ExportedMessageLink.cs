using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ExportedMessageLink : CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase
	{


        public static int StaticConstructorId { get => 1571494644; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("link")]
		public override string Link { get; set; }

[JsonPropertyName("html")]
		public override string Html { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Link);
			writer.Write(Html);

		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();
			Html = reader.Read<string>();

		}
	}
}