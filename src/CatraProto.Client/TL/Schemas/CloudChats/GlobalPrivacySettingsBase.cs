using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GlobalPrivacySettingsBase : IObject
    {
		public abstract bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
