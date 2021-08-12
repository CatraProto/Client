using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTheme : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1919060949; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ThemeBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("format")]
		public string Format { get; set; }

[JsonPropertyName("theme")]
		public InputThemeBase Theme { get; set; }

[JsonPropertyName("document_id")]
		public long DocumentId { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Format);
			writer.Write(Theme);
			writer.Write(DocumentId);

		}

		public void Deserialize(Reader reader)
		{
			Format = reader.Read<string>();
			Theme = reader.Read<InputThemeBase>();
			DocumentId = reader.Read<long>();
		}

		public override string ToString()
		{
			return "account.getTheme";
		}
	}
}