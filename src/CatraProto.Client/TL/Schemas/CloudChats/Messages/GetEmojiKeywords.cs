using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetEmojiKeywords : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 899735650; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EmojiKeywordsDifferenceBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("lang_code")]
		public string LangCode { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(LangCode);

		}

		public void Deserialize(Reader reader)
		{
			LangCode = reader.Read<string>();
		}

		public override string ToString()
		{
			return "messages.getEmojiKeywords";
		}
	}
}