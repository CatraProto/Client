using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeBase : IObject
    {
		public abstract bool Creator { get; set; }
		public abstract bool Default { get; set; }
		public abstract long Id { get; set; }
		public abstract long AccessHash { get; set; }
		public abstract string Slug { get; set; }
		public abstract string Title { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }
		public abstract int InstallsCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
