using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewEncryptedMessage : UpdateBase
	{


        public static int StaticConstructorId { get => 314359194; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("message")]
		public EncryptedMessageBase Message { get; set; }

[JsonPropertyName("qts")]
		public int Qts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<EncryptedMessageBase>();
			Qts = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateNewEncryptedMessage";
		}
	}
}