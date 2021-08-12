using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatFull : ChatFullBase
	{


        public static int StaticConstructorId { get => -438840932; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonPropertyName("full_chat")] public override CloudChats.ChatFullBase FullChat { get; set; }

        [JsonPropertyName("chats")] public override IList<ChatBase> Chats { get; set; }

        [JsonPropertyName("users")] public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FullChat);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			FullChat = reader.Read<CloudChats.ChatFullBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}

		public override string ToString()
		{
			return "messages.chatFull";
		}
	}
}