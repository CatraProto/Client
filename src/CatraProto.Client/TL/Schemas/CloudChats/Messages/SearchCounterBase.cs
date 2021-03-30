using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class SearchCounterBase : IObject
    {
		public abstract bool Inexact { get; set; }
		public abstract MessagesFilterBase Filter { get; set; }
		public abstract int Count { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
