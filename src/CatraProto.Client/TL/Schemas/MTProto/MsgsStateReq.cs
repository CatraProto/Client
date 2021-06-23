using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgsStateReq : MsgsStateReqBase
	{
		public static int ConstructorId { get; } = -630588590;
		public override IList<long> MsgIds { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(MsgIds);
		}

		public override void Deserialize(Reader reader)
		{
			MsgIds = reader.ReadVector<long>();
		}
	}
}