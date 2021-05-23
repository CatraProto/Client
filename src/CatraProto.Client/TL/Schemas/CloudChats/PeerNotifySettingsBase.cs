using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerNotifySettingsBase : IObject
    {
		public abstract bool? ShowPreviews { get; set; }
		public abstract bool? Silent { get; set; }
		public abstract int? MuteUntil { get; set; }
		public abstract string Sound { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
