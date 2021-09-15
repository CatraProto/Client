using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputEncryptedChat : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase
	{


        public static int StaticConstructorId { get => -247351839; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public override int ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public override long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatId);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputEncryptedChat";
		}
	}
}