using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetPrivacy : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -906486552; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("key")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }

[Newtonsoft.Json.JsonProperty("rules")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> Rules { get; set; }

        
        #nullable enable
 public SetPrivacy (CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key,IList<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> rules)
{
 Key = key;
Rules = rules;
 
}
#nullable disable
                
        internal SetPrivacy() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Rules);

		}

		public void Deserialize(Reader reader)
		{
			Key = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase>();
			Rules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase>();

		}
		
		public override string ToString()
		{
		    return "account.setPrivacy";
		}
	}
}