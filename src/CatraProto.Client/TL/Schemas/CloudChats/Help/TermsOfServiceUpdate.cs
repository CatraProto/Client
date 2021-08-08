using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class TermsOfServiceUpdate : TermsOfServiceUpdateBase
	{


        public static int StaticConstructorId { get => 686618977; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("expires")]
		public override int Expires { get; set; }

[JsonPropertyName("terms_of_service")]
		public TermsOfServiceBase TermsOfService { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);
			writer.Write(TermsOfService);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
			TermsOfService = reader.Read<TermsOfServiceBase>();

		}
	}
}