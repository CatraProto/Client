using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public abstract class AuthorizationFormBase : IObject
	{
		public abstract IList<SecureRequiredTypeBase> RequiredTypes { get; set; }
		public abstract IList<SecureValueBase> Values { get; set; }
		public abstract IList<SecureValueErrorBase> Errors { get; set; }
		public abstract IList<UserBase> Users { get; set; }
		public abstract string PrivacyPolicyUrl { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}