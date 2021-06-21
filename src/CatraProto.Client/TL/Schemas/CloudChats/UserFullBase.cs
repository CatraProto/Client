using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class UserFullBase : IObject
    {
		public abstract bool Blocked { get; set; }
		public abstract bool PhoneCallsAvailable { get; set; }
		public abstract bool PhoneCallsPrivate { get; set; }
		public abstract bool CanPinMessage { get; set; }
		public abstract bool HasScheduled { get; set; }
		public abstract bool VideoCallsAvailable { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }
		public abstract string About { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }
		public abstract int? PinnedMsgId { get; set; }
		public abstract int CommonChatsCount { get; set; }
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
