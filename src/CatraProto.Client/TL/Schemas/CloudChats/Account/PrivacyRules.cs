using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PrivacyRules : PrivacyRulesBase
	{
		public static int ConstructorId { get; } = 1352683077;
		public override IList<PrivacyRuleBase> Rules { get; set; }
		public override IList<ChatBase> Chats { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Rules);
			writer.Write(Chats);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Rules = reader.ReadVector<PrivacyRuleBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}