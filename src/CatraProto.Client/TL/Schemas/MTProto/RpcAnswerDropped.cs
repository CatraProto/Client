using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class RpcAnswerDropped : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
	{


        public static int StaticConstructorId { get => -1539647305; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_id")]
		public long MsgId { get; set; }

[JsonPropertyName("seq_no")]
		public int SeqNo { get; set; }

[JsonPropertyName("bytes")]
		public int Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(SeqNo);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			SeqNo = reader.Read<int>();
			Bytes = reader.Read<int>();

		}
	}
}