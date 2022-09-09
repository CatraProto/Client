using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputThemeSettingsBase : IObject
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
        public abstract List<int> MessageColors { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("wallpaper")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("wallpaper_settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase WallpaperSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}