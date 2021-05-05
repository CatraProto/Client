using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public abstract class StateBase : IObject
    {
		public abstract int Pts { get; set; }
		public abstract int Qts { get; set; }
		public abstract int Date { get; set; }
		public abstract int Seq { get; set; }
		public abstract int UnreadCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
