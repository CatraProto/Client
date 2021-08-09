using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Pong : CatraProto.Client.TL.Schemas.MTProto.PongBase
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
	}
}