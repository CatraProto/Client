using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgDetailedInfo : MsgDetailedInfoBase
	{


        public static int StaticConstructorId { get => 661470918; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_id")]
		public long MsgId { get; set; }

[JsonPropertyName("answer_msg_id")]
		public override long AnswerMsgId { get; set; }

[JsonPropertyName("bytes")]
		public override int Bytes { get; set; }

[JsonPropertyName("status")]
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
	}
}