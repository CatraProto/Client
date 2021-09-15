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


        public static int StaticConstructorId { get => 661470918; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("msg_id")]
		public long MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("answer_msg_id")]
		public override long AnswerMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public override int Bytes { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public override int Status { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}