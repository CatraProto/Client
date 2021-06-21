using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeSettingsBase : IObject
    {
        public abstract BaseThemeBase BaseTheme { get; set; }
        public abstract int AccentColor { get; set; }
        public abstract int? MessageTopColor { get; set; }
        public abstract int? MessageBottomColor { get; set; }
        public abstract WallPaperBase Wallpaper { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}