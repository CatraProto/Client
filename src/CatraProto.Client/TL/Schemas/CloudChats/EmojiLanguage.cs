using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiLanguage : EmojiLanguageBase
	{


        public static int StaticConstructorId { get => -1275374751; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("lang_code")]
		public override string LangCode { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);

		}

		public override void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
		}

		public override string ToString()
		{
			return "emojiLanguage";
		}
	}
}