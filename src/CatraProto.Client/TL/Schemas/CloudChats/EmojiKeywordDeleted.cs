using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiKeywordDeleted : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 594408994; }
        
[Newtonsoft.Json.JsonProperty("keyword")]
		public sealed override string Keyword { get; set; }

[Newtonsoft.Json.JsonProperty("emoticons")]
		public sealed override IList<string> Emoticons { get; set; }


        #nullable enable
 public EmojiKeywordDeleted (string keyword,IList<string> emoticons)
{
 Keyword = keyword;
Emoticons = emoticons;
 
}
#nullable disable
        internal EmojiKeywordDeleted() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Keyword);
			writer.Write(Emoticons);

		}

		public override void Deserialize(Reader reader)
		{
			Keyword = reader.Read<string>();
			Emoticons = reader.ReadVector<string>();

		}
		
		public override string ToString()
		{
		    return "emojiKeywordDeleted";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}