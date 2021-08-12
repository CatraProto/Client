using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageViews : MessageViewsBase
	{


        public static int StaticConstructorId { get => -1228606141; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonPropertyName("views")] public override IList<CloudChats.MessageViewsBase> Views { get; set; }

        [JsonPropertyName("chats")] public override IList<ChatBase> Chats { get; set; }

        [JsonPropertyName("users")] public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Views);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Views = reader.ReadVector<CloudChats.MessageViewsBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}

		public override string ToString()
		{
			return "messages.messageViews";
		}
	}
}