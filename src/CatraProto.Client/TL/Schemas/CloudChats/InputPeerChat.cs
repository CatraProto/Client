using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerChat : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
	{


        public static int StaticConstructorId { get => 396093539; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("chat_id")]
		public int ChatId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();

		}
	}
}