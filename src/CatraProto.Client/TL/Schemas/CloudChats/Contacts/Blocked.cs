using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class Blocked : BlockedBase
	{


        public static int StaticConstructorId { get => 182326673; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("Blocked_")]
		public override IList<PeerBlockedBase> Blocked_ { get; set; }

[JsonPropertyName("chats")]
		public override IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Blocked_);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Blocked_ = reader.ReadVector<PeerBlockedBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}