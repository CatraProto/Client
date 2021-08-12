using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteAlready : ChatInviteBase
	{


        public static int StaticConstructorId { get => 1516793212; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat")]
		public ChatBase Chat { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<ChatBase>();
		}

		public override string ToString()
		{
			return "chatInviteAlready";
		}
	}
}