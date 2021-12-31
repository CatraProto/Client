using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputThemeSettings : CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			MessageColorsAnimated = 1 << 2,
			OutboxAccentColor = 1 << 3,
			MessageColors = 1 << 0,
			Wallpaper = 1 << 1,
			WallpaperSettings = 1 << 1
		}

        public static int StaticConstructorId { get => -1881255857; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("message_colors_animated")]
		public override bool MessageColorsAnimated { get; set; }

[Newtonsoft.Json.JsonProperty("base_theme")]
		public override CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }

[Newtonsoft.Json.JsonProperty("accent_color")]
		public override int AccentColor { get; set; }

[Newtonsoft.Json.JsonProperty("outbox_accent_color")]
		public override int? OutboxAccentColor { get; set; }

[Newtonsoft.Json.JsonProperty("message_colors")]
		public override IList<int> MessageColors { get; set; }

[Newtonsoft.Json.JsonProperty("wallpaper")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

[Newtonsoft.Json.JsonProperty("wallpaper_settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase WallpaperSettings { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = MessageColorsAnimated ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = OutboxAccentColor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = MessageColors == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Wallpaper == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = WallpaperSettings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(BaseTheme);
			writer.Write(AccentColor);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(OutboxAccentColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(MessageColors);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Wallpaper);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(WallpaperSettings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			MessageColorsAnimated = FlagsHelper.IsFlagSet(Flags, 2);
			BaseTheme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase>();
			AccentColor = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				OutboxAccentColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				MessageColors = reader.ReadVector<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Wallpaper = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				WallpaperSettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
			}


		}
				
		public override string ToString()
		{
		    return "inputThemeSettings";
		}
	}
}