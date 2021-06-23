using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class SecureSecretSettingsBase : IObject
	{
		public abstract SecurePasswordKdfAlgoBase SecureAlgo { get; set; }
		public abstract byte[] SecureSecret { get; set; }
		public abstract long SecureSecretId { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}