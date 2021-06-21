using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputThemeSettingsBase : IObject
    {
        public abstract BaseThemeBase BaseTheme { get; set; }
        public abstract int AccentColor { get; set; }
        public abstract int? MessageTopColor { get; set; }
        public abstract int? MessageBottomColor { get; set; }
        public abstract InputWallPaperBase Wallpaper { get; set; }
        public abstract WallPaperSettingsBase WallpaperSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}