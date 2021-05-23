using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AutoDownloadSettingsBase : IObject
    {
		public abstract bool Disabled { get; set; }
		public abstract bool VideoPreloadLarge { get; set; }
		public abstract bool AudioPreloadNext { get; set; }
		public abstract bool PhonecallsLessData { get; set; }
		public abstract int PhotoSizeMax { get; set; }
		public abstract int VideoSizeMax { get; set; }
		public abstract int FileSizeMax { get; set; }
		public abstract int VideoUploadMaxbitrate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
