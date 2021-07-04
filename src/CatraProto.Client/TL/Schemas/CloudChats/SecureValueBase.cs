using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureValueBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase FrontSide { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase ReverseSide { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase Selfie { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Translation { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Files { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }
		public abstract byte[] Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
