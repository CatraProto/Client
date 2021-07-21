using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Message : CatraProto.Client.TL.Schemas.MTProto.MessageBase
	{


        public static int StaticConstructorId { get => 0; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_id")]
		public override long MsgId { get; set; }

[JsonPropertyName("seqno")]
		public override int Seqno { get; set; }

[JsonPropertyName("bytes")]
		public override int Bytes { get; set; }

[JsonPropertyName("body")]
		public override IObject Body { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Seqno);
			writer.Write(Bytes);
			writer.Write(Body);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<long>();
			Seqno = reader.Read<int>();
			Bytes = reader.Read<int>();
			Body = reader.Read<IObject>();

		}
	}
}