using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureValueBase : IObject
    {
		public abstract SecureValueTypeBase Type { get; set; }
		public abstract SecureDataBase Data { get; set; }
		public abstract SecureFileBase FrontSide { get; set; }
		public abstract SecureFileBase ReverseSide { get; set; }
		public abstract SecureFileBase Selfie { get; set; }
		public abstract IList<SecureFileBase> Translation { get; set; }
		public abstract IList<SecureFileBase> Files { get; set; }
		public abstract SecurePlainDataBase PlainData { get; set; }
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
