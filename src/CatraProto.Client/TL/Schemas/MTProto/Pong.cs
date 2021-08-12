using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Pong : PongBase
	{


        public static int StaticConstructorId { get => 880243653; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_id")]
		public override long MsgId { get; set; }

[JsonPropertyName("ping_id")]
		public override long PingId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(PingId);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			PingId = reader.Read<long>();
		}

		public override string ToString()
		{
			return "pong";
		}
	}
}