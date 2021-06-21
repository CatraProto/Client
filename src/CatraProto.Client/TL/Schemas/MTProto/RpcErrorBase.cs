using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class RpcErrorBase : IObject
    {
		public abstract int ErrorCode { get; set; }
		public abstract string ErrorMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
