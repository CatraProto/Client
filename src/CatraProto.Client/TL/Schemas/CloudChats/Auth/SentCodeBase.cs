using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }
		public abstract string PhoneCodeHash { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }
		public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
