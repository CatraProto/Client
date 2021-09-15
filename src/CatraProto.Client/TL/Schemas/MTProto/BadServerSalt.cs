using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BadServerSalt : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
	{


        public static int StaticConstructorId { get => -307542917; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("bad_msg_id")]
		public override long BadMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bad_msg_seqno")]
		public override int BadMsgSeqno { get; set; }

[Newtonsoft.Json.JsonProperty("error_code")]
		public override int ErrorCode { get; set; }

[Newtonsoft.Json.JsonProperty("new_server_salt")]
		public long NewServerSalt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BadMsgId);
			writer.Write(BadMsgSeqno);
			writer.Write(ErrorCode);
			writer.Write(NewServerSalt);

		}

		public override void Deserialize(Reader reader)
		{
			BadMsgId = reader.Read<long>();
			BadMsgSeqno = reader.Read<int>();
			ErrorCode = reader.Read<int>();
			NewServerSalt = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "bad_server_salt";
		}
	}
}