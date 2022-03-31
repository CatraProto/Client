using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgDetailedInfo : CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 661470918; }
        
[Newtonsoft.Json.JsonProperty("msg_id")]
		public long MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("answer_msg_id")]
		public sealed override long AnswerMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public sealed override int Bytes { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public sealed override int Status { get; set; }


        #nullable enable
 public MsgDetailedInfo (long msgId,long answerMsgId,int bytes,int status)
{
 MsgId = msgId;
AnswerMsgId = answerMsgId;
Bytes = bytes;
Status = status;
 
}
#nullable disable
        internal MsgDetailedInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(AnswerMsgId);
			writer.Write(Bytes);
			writer.Write(Status);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			AnswerMsgId = reader.Read<long>();
			Bytes = reader.Read<int>();
			Status = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "msg_detailed_info";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}