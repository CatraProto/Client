using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BadMsgNotification : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
	{


        public static int StaticConstructorId { get => -1477445615; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("bad_msg_id")]
		public override long BadMsgId { get; set; }

[JsonPropertyName("bad_msg_seqno")]
		public override int BadMsgSeqno { get; set; }

[JsonPropertyName("error_code")]
		public override int ErrorCode { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BadMsgId);
			writer.Write(BadMsgSeqno);
			writer.Write(ErrorCode);

		}

		public override void Deserialize(Reader reader)
		{
			BadMsgId = reader.Read<long>();
			BadMsgSeqno = reader.Read<int>();
			ErrorCode = reader.Read<int>();

		}
	}
}