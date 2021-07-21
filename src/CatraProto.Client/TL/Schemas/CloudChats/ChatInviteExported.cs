using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteExported : CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase
	{


        public static int StaticConstructorId { get => -64092740; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("link")]
		public string Link { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Link);

		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();

		}
	}
}