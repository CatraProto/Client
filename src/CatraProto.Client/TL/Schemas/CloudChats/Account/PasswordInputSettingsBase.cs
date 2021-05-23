using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordInputSettingsBase : IObject
    {
		public abstract PasswordKdfAlgoBase NewAlgo { get; set; }
		public abstract byte[] NewPasswordHash { get; set; }
		public abstract string Hint { get; set; }
		public abstract string Email { get; set; }
		public abstract SecureSecretSettingsBase NewSecureSettings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
