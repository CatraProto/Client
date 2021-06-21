using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeSettingsBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase BaseTheme { get; set; }
		public abstract int AccentColor { get; set; }
		public abstract int? MessageTopColor { get; set; }
		public abstract int? MessageBottomColor { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase Wallpaper { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
