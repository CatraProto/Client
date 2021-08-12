using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnConfig : CdnConfigBase
	{


        public static int StaticConstructorId { get => 1462101002; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("public_keys")]
		public override IList<CdnPublicKeyBase> PublicKeys { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PublicKeys);

		}

		public override void Deserialize(Reader reader)
		{
			PublicKeys = reader.ReadVector<CdnPublicKeyBase>();
		}

		public override string ToString()
		{
			return "cdnConfig";
		}
	}
}