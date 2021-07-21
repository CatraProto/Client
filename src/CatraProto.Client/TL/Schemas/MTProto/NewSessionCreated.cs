using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class NewSessionCreated : CatraProto.Client.TL.Schemas.MTProto.NewSessionBase
	{


        public static int StaticConstructorId { get => -1631450872; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("first_msg_id")]
		public override long FirstMsgId { get; set; }

[JsonPropertyName("unique_id")]
		public override long UniqueId { get; set; }

[JsonPropertyName("server_salt")]
		public override long ServerSalt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FirstMsgId);
			writer.Write(UniqueId);
			writer.Write(ServerSalt);

		}

		public override void Deserialize(Reader reader)
		{
			FirstMsgId = reader.Read<long>();
			UniqueId = reader.Read<long>();
			ServerSalt = reader.Read<long>();

		}
	}
}