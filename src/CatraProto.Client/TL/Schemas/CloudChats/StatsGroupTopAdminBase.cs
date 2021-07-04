using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StatsGroupTopAdminBase : IObject
    {
		public abstract int UserId { get; set; }
		public abstract int Deleted { get; set; }
		public abstract int Kicked { get; set; }
		public abstract int Banned { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
