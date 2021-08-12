using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgNewDetailedInfo : MsgDetailedInfoBase
	{


        public static int StaticConstructorId { get => -2137147681; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
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
	}
}