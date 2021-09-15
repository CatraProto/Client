using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAuthorDate : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => -1162877472; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("author")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Author { get; set; }

[Newtonsoft.Json.JsonProperty("published_date")]
		public int PublishedDate { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Author);
			writer.Write(PublishedDate);

		}

		public override void Deserialize(Reader reader)
		{
			Author = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			PublishedDate = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "pageBlockAuthorDate";
		}
	}
}