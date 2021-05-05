using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotCallbackAnswerBase : IObject
    {
		public abstract bool Alert { get; set; }
		public abstract bool HasUrl { get; set; }
		public abstract bool NativeUi { get; set; }
		public abstract string Message { get; set; }
		public abstract string Url { get; set; }
		public abstract int CacheTime { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
