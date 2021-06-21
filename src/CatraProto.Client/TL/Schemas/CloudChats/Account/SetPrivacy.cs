using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetPrivacy : IMethod
	{
		public static int ConstructorId { get; } = -906486552;
		public InputPrivacyKeyBase Key { get; set; }
		public IList<InputPrivacyRuleBase> Rules { get; set; }

		public Type Type { get; init; } = typeof(PrivacyRulesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
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