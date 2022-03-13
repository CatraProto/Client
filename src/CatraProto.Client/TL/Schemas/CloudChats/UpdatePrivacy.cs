using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePrivacy : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -298113238; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("key")]
		public CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase Key { get; set; }

[Newtonsoft.Json.JsonProperty("rules")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> Rules { get; set; }


        #nullable enable
 public UpdatePrivacy (CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase key,IList<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> rules)
{
 Key = key;
Rules = rules;
 
}
#nullable disable
        internal UpdatePrivacy() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Rules);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase>();
			Rules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase>();

		}
				
		public override string ToString()
		{
		    return "updatePrivacy";
		}
	}
}