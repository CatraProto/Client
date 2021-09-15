using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class NewSessionCreated : CatraProto.Client.TL.Schemas.MTProto.NewSessionBase
	{


        public static int StaticConstructorId { get => -1631450872; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("first_msg_id")]
		public override long FirstMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("unique_id")]
		public override long UniqueId { get; set; }

[Newtonsoft.Json.JsonProperty("server_salt")]
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
				
		public override string ToString()
		{
		    return "new_session_created";
		}
	}
}