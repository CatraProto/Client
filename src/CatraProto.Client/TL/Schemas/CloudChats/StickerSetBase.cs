using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerSetBase : IObject
    {
		public abstract bool Archived { get; set; }
		public abstract bool Official { get; set; }
		public abstract bool Masks { get; set; }
		public abstract bool Animated { get; set; }
		public abstract int? InstalledDate { get; set; }
		public abstract long Id { get; set; }
		public abstract long AccessHash { get; set; }
		public abstract string Title { get; set; }
		public abstract string ShortName { get; set; }
		public abstract PhotoSizeBase Thumb { get; set; }
		public abstract int? ThumbDcId { get; set; }
		public abstract int Count { get; set; }
		public abstract int Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
