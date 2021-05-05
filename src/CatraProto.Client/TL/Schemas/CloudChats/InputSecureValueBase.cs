using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSecureValueBase : IObject
    {
		public abstract SecureValueTypeBase Type { get; set; }
		public abstract SecureDataBase Data { get; set; }
		public abstract InputSecureFileBase FrontSide { get; set; }
		public abstract InputSecureFileBase ReverseSide { get; set; }
		public abstract InputSecureFileBase Selfie { get; set; }
		public abstract IList<InputSecureFileBase> Translation { get; set; }
		public abstract IList<InputSecureFileBase> Files { get; set; }
		public abstract SecurePlainDataBase PlainData { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
