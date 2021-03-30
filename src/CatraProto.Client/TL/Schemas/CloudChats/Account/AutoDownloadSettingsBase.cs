using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AutoDownloadSettingsBase : IObject
    {
		public abstract AutoDownloadSettingsBase Low { get; set; }
		public abstract AutoDownloadSettingsBase Medium { get; set; }
		public abstract AutoDownloadSettingsBase High { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
