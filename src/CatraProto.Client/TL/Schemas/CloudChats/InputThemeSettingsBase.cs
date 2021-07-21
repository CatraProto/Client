using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputThemeSettingsBase : IObject
    {

[JsonPropertyName("base_theme")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }

[JsonPropertyName("accent_color")]
		public abstract int AccentColor { get; set; }

[JsonPropertyName("message_top_color")]
		public abstract int? MessageTopColor { get; set; }

[JsonPropertyName("message_bottom_color")]
		public abstract int? MessageBottomColor { get; set; }

[JsonPropertyName("wallpaper")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

[JsonPropertyName("wallpaper_settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase WallpaperSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
