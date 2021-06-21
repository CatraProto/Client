using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatFullBase : IObject
    {
		public abstract bool CanSetUsername { get; set; }
		public abstract bool HasScheduled { get; set; }
		public abstract int Id { get; set; }
		public abstract string About { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }
		public abstract int? PinnedMsgId { get; set; }
		public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
