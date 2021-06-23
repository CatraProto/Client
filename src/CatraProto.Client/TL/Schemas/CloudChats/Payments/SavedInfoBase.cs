using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public abstract class SavedInfoBase : IObject
	{
		public abstract bool HasSavedCredentials { get; set; }
		public abstract PaymentRequestedInfoBase SavedInfo_ { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}