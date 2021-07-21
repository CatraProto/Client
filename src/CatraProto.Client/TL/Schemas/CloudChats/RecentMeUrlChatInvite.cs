using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlChatInvite : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
	{


        public static int StaticConstructorId { get => -347535331; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public override string Url { get; set; }

[JsonPropertyName("chat_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase ChatInvite { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(ChatInvite);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			ChatInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>();

		}
	}
}