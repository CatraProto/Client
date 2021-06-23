using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSecureValuesSent : MessageActionBase
	{
		public static int ConstructorId { get; } = -648257196;
		public IList<SecureValueTypeBase> Types { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Types);
		}

		public override void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<SecureValueTypeBase>();
		}
	}
}