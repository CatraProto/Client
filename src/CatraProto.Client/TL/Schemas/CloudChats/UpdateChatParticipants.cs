using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatParticipants : UpdateBase
	{


        public static int StaticConstructorId { get => 125178264; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("participants")]
		public ChatParticipantsBase Participants { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participants);

		}

		public override void Deserialize(Reader reader)
		{
			Participants = reader.Read<ChatParticipantsBase>();
		}

		public override string ToString()
		{
			return "updateChatParticipants";
		}
	}
}