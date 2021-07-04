using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopPosterBase : IObject
    {
		public abstract int UserId { get; set; }
		public abstract int Messages { get; set; }
		public abstract int AvgChars { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
