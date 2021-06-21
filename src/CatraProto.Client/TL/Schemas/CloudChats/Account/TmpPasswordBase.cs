using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class TmpPasswordBase : IObject
    {
		public abstract byte[] TmpPassword_ { get; set; }
		public abstract int ValidUntil { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
