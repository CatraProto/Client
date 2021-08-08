using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateEncryption : UpdateBase
	{


        public static int StaticConstructorId { get => -1264392051; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat")]
		public EncryptedChatBase Chat { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<EncryptedChatBase>();
			Date = reader.Read<int>();

		}
	}
}