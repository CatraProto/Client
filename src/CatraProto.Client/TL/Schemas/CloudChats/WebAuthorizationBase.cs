using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebAuthorizationBase : IObject
    {
		public abstract long Hash { get; set; }
		public abstract int BotId { get; set; }
		public abstract string Domain { get; set; }
		public abstract string Browser { get; set; }
		public abstract string Platform { get; set; }
		public abstract int DateCreated { get; set; }
		public abstract int DateActive { get; set; }
		public abstract string Ip { get; set; }
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
