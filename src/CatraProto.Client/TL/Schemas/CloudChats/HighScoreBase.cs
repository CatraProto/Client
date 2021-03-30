using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class HighScoreBase : IObject
    {
		public abstract int Pos { get; set; }
		public abstract int UserId { get; set; }
		public abstract int Score { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
