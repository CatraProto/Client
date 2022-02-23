using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeSettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("message_colors_animated")]
		public abstract bool MessageColorsAnimated { get; set; }

[Newtonsoft.Json.JsonProperty("base_theme")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }

[Newtonsoft.Json.JsonProperty("accent_color")]
		public abstract int AccentColor { get; set; }

[Newtonsoft.Json.JsonProperty("outbox_accent_color")]
		public abstract int? OutboxAccentColor { get; set; }

[Newtonsoft.Json.JsonProperty("message_colors")]
		public abstract IList<int> MessageColors { get; set; }

[Newtonsoft.Json.JsonProperty("wallpaper")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase Wallpaper { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
