using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class BlockedSlice : CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase
	{


        public static int StaticConstructorId { get => -513392236; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("count")]
		public int Count { get; set; }

[JsonPropertyName("Blocked_")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> Blocked_ { get; set; }

[JsonPropertyName("chats")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Blocked_);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Blocked_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}