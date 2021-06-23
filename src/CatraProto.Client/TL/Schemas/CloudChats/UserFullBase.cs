using CatraProto.TL;
using CatraProto.TL.Interfaces;

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
		public abstract UserBase User { get; set; }
		public abstract string About { get; set; }
		public abstract PeerSettingsBase Settings { get; set; }
		public abstract PhotoBase ProfilePhoto { get; set; }
		public abstract PeerNotifySettingsBase NotifySettings { get; set; }
		public abstract BotInfoBase BotInfo { get; set; }
		public abstract int? PinnedMsgId { get; set; }
		public abstract int CommonChatsCount { get; set; }
		public abstract int? FolderId { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}