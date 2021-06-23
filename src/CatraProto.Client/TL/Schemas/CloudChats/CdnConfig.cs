using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnConfig : CdnConfigBase
	{
		public static int ConstructorId { get; } = 1462101002;
		public override IList<CdnPublicKeyBase> PublicKeys { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PublicKeys);
		}

		public override void Deserialize(Reader reader)
		{
			PublicKeys = reader.ReadVector<CdnPublicKeyBase>();
		}
	}
}