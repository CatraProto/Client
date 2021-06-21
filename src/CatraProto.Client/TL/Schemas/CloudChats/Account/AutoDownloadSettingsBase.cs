using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AutoDownloadSettingsBase : IObject
    {
        public abstract CloudChats.AutoDownloadSettingsBase Low { get; set; }
        public abstract CloudChats.AutoDownloadSettingsBase Medium { get; set; }
        public abstract CloudChats.AutoDownloadSettingsBase High { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}