using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperSettingsBase : IObject
    {
		public abstract bool Blur { get; set; }
		public abstract bool Motion { get; set; }
		public abstract int? BackgroundColor { get; set; }
		public abstract int? SecondBackgroundColor { get; set; }
		public abstract int? Intensity { get; set; }
		public abstract int? Rotation { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
