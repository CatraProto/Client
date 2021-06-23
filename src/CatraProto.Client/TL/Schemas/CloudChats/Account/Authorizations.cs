using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Authorizations : AuthorizationsBase
	{
		public static int ConstructorId { get; } = 307276766;
		public override IList<AuthorizationBase> Authorizations_ { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Authorizations_);
		}

		public override void Deserialize(Reader reader)
		{
			Authorizations_ = reader.ReadVector<AuthorizationBase>();
		}
	}
}