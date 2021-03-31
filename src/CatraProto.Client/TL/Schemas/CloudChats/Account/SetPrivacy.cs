using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetPrivacy : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>
	{


        public static int ConstructorId { get; } = -906486552;

		public InputPrivacyKeyBase Key { get; set; }
		public IList<InputPrivacyRuleBase> Rules { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Rules);

		}

		public void Deserialize(Reader reader)
		{
			Key = reader.Read<InputPrivacyKeyBase>();
			Rules = reader.ReadVector<InputPrivacyRuleBase>();

		}
	}
}