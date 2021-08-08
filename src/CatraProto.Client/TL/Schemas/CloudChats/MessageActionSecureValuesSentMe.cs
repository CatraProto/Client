using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionSecureValuesSentMe : MessageActionBase
	{


        public static int StaticConstructorId { get => 455635795; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("values")]
		public IList<SecureValueBase> Values { get; set; }

[JsonPropertyName("credentials")]
		public SecureCredentialsEncryptedBase Credentials { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Values);
			writer.Write(Credentials);

		}

		public override void Deserialize(Reader reader)
		{
			Values = reader.ReadVector<SecureValueBase>();
			Credentials = reader.Read<SecureCredentialsEncryptedBase>();

		}
	}
}