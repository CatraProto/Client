using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class PrivacyRules : PrivacyRulesBase
	{


        public static int StaticConstructorId { get => 1352683077; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("rules")]
		public override IList<PrivacyRuleBase> Rules { get; set; }

[JsonPropertyName("chats")]
		public override IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

        
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
			Rules = reader.ReadVector<PrivacyRuleBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}

		public override string ToString()
		{
			return "account.privacyRules";
		}
	}
}