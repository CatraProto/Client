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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1162877472; }
        
[Newtonsoft.Json.JsonProperty("author")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Author { get; set; }

[Newtonsoft.Json.JsonProperty("published_date")]
		public int PublishedDate { get; set; }


        #nullable enable
 public PageBlockAuthorDate (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase author,int publishedDate)
{
 Author = author;
PublishedDate = publishedDate;
 
}
#nullable disable
        internal PageBlockAuthorDate() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}