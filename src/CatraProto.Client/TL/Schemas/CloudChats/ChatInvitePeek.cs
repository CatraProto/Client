using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInvitePeek : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
	{


        public static int StaticConstructorId { get => 1634294960; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

[JsonPropertyName("expires")]
		public int Expires { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chat);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Expires = reader.Read<int>();

		}
	}
}