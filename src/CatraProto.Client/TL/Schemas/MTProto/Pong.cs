using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Pong : CatraProto.Client.TL.Schemas.MTProto.PongBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 880243653; }
        
[Newtonsoft.Json.JsonProperty("msg_id")]
		public sealed override long MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("ping_id")]
		public sealed override long PingId { get; set; }


        #nullable enable
 public Pong (long msgId,long pingId)
{
 MsgId = msgId;
PingId = pingId;
 
}
#nullable disable
        internal Pong() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}