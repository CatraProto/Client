using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class PasswordRecovery : PasswordRecoveryBase
	{


        public static int StaticConstructorId { get => 326715557; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("email_pattern")]
		public override string EmailPattern { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(EmailPattern);

		}

		public override void Deserialize(Reader reader)
		{
			EmailPattern = reader.Read<string>();
		}

		public override string ToString()
		{
			return "auth.passwordRecovery";
		}
	}
}