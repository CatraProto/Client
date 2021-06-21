using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueDisallowUsers : InputPrivacyRuleBase
	{
		public static int ConstructorId { get; } = -1877932953;
		public IList<InputUserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<InputUserBase>();
		}
	}
}