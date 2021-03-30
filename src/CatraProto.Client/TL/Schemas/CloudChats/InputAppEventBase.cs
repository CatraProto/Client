using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputAppEventBase : IObject
    {
		public abstract double Time { get; set; }
		public abstract string Type { get; set; }
		public abstract long Peer { get; set; }
		public abstract JSONValueBase Data { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
