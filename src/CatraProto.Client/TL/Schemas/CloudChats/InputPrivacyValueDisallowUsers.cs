using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPrivacyValueDisallowUsers : InputPrivacyRuleBase
	{


        public static int StaticConstructorId { get => -1877932953; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("users")]
		public IList<InputUserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<InputUserBase>();
		}

		public override string ToString()
		{
			return "inputPrivacyValueDisallowUsers";
		}
	}
}