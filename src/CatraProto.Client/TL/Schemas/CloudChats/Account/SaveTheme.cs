using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveTheme : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -229175188; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("theme")]
		public InputThemeBase Theme { get; set; }

[JsonPropertyName("unsave")]
		public bool Unsave { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Theme);
			writer.Write(Unsave);

		}

		public void Deserialize(Reader reader)
		{
			Theme = reader.Read<InputThemeBase>();
			Unsave = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "account.saveTheme";
		}
	}
}