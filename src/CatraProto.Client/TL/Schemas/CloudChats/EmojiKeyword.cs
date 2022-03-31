using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiKeyword : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -709641735; }
        
[Newtonsoft.Json.JsonProperty("keyword")]
		public sealed override string Keyword { get; set; }

[Newtonsoft.Json.JsonProperty("emoticons")]
		public sealed override IList<string> Emoticons { get; set; }


        #nullable enable
 public EmojiKeyword (string keyword,IList<string> emoticons)
{
 Keyword = keyword;
Emoticons = emoticons;
 
}
#nullable disable
        internal EmojiKeyword() 
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
		    return "emojiKeyword";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}