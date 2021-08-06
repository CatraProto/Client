using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteAlready : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
	{


        public static int StaticConstructorId { get => 1516793212; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

        
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
			Chat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
	}
}