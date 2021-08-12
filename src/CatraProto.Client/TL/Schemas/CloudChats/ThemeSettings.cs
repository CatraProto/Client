using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ThemeSettings : ThemeSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			MessageTopColor = 1 << 0,
			MessageBottomColor = 1 << 0,
			Wallpaper = 1 << 1
		}

        public static int StaticConstructorId { get => -1676371894; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("base_theme")]
		public override BaseThemeBase BaseTheme { get; set; }

[JsonPropertyName("accent_color")]
		public override int AccentColor { get; set; }

[JsonPropertyName("message_top_color")]
		public override int? MessageTopColor { get; set; }

[JsonPropertyName("message_bottom_color")]
		public override int? MessageBottomColor { get; set; }

[JsonPropertyName("wallpaper")]
		public override WallPaperBase Wallpaper { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = MessageTopColor == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = MessageBottomColor == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Wallpaper == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(BaseTheme);
			writer.Write(AccentColor);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MessageTopColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MessageBottomColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Wallpaper);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			BaseTheme = reader.Read<BaseThemeBase>();
			AccentColor = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MessageTopColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MessageBottomColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Wallpaper = reader.Read<WallPaperBase>();
			}
		}

		public override string ToString()
		{
			return "themeSettings";
		}
	}
}