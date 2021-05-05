using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PollAnswerVotersBase : IObject
    {
		public abstract bool Chosen { get; set; }
		public abstract bool Correct { get; set; }
		public abstract byte[] Option { get; set; }
		public abstract int Voters { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
