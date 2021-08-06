using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class CreateTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Document = 1 << 2,
			Settings = 1 << 3
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -2077048289; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.ThemeBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("slug")]
		public string Slug { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[JsonPropertyName("settings")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase Settings { get; set; }


		public void UpdateFlags() 
		{
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Slug);
			writer.Write(Title);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Document);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Settings);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Slug = reader.Read<string>();
			Title = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase>();
			}


		}
	}
}