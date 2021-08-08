using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePrivacy : UpdateBase
	{


        public static int StaticConstructorId { get => -298113238; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("key")]
		public PrivacyKeyBase Key { get; set; }

[JsonPropertyName("rules")]
		public IList<PrivacyRuleBase> Rules { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Key);
			writer.Write(Rules);

		}

		public override void Deserialize(Reader reader)
		{
			Key = reader.Read<PrivacyKeyBase>();
			Rules = reader.ReadVector<PrivacyRuleBase>();

		}
	}
}