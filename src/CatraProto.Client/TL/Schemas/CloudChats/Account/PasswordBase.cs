using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordBase : IObject
    {
		public abstract bool HasRecovery { get; set; }
		public abstract bool HasSecureValues { get; set; }
		public abstract bool HasPassword { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase CurrentAlgo { get; set; }
		public abstract byte[] SrpB { get; set; }
		public abstract long? SrpId { get; set; }
		public abstract string Hint { get; set; }
		public abstract string EmailUnconfirmedPattern { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase NewSecureAlgo { get; set; }
		public abstract byte[] SecureRandom { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
