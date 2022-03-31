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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1631450872; }
        
[Newtonsoft.Json.JsonProperty("first_msg_id")]
		public sealed override long FirstMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("unique_id")]
		public sealed override long UniqueId { get; set; }

[Newtonsoft.Json.JsonProperty("server_salt")]
		public sealed override long ServerSalt { get; set; }


        #nullable enable
 public NewSessionCreated (long firstMsgId,long uniqueId,long serverSalt)
{
 FirstMsgId = firstMsgId;
UniqueId = uniqueId;
ServerSalt = serverSalt;
 
}
#nullable disable
        internal NewSessionCreated() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}