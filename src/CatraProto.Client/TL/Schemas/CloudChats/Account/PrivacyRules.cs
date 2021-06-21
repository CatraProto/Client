using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PrivacyRules : PrivacyRulesBase
	{


        public static int ConstructorId { get; } = 1352683077;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> Rules { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Rules);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Rules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}