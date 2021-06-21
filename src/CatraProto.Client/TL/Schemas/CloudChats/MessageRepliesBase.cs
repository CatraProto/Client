using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageRepliesBase : IObject
    {
		public abstract bool Comments { get; set; }
		public abstract int Replies { get; set; }
		public abstract int RepliesPts { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }
		public abstract int? ChannelId { get; set; }
		public abstract int? MaxId { get; set; }
		public abstract int? ReadMaxId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
