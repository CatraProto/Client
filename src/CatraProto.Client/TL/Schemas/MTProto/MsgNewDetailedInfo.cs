using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgNewDetailedInfo : CatraProto.Client.TL.Schemas.MTProto.MsgDetailedInfoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2137147681; }
        
[Newtonsoft.Json.JsonProperty("answer_msg_id")]
		public sealed override long AnswerMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public sealed override int Bytes { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public sealed override int Status { get; set; }


        #nullable enable
 public MsgNewDetailedInfo (long answerMsgId,int bytes,int status)
{
 AnswerMsgId = answerMsgId;
Bytes = bytes;
Status = status;
 
}
#nullable disable
        internal MsgNewDetailedInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(AnswerMsgId);
			writer.Write(Bytes);
			writer.Write(Status);

		}

		public override void Deserialize(Reader reader)
		{
			AnswerMsgId = reader.Read<long>();
			Bytes = reader.Read<int>();
			Status = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "msg_new_detailed_info";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}