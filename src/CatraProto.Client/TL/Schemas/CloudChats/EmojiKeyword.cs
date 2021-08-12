using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiKeyword : EmojiKeywordBase
	{


        public static int StaticConstructorId { get => -709641735; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("keyword")]
		public override string Keyword { get; set; }

[JsonPropertyName("emoticons")]
		public override IList<string> Emoticons { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}