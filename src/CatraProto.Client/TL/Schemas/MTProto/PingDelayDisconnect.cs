using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PingDelayDisconnect : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -213746804; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.PongBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("ping_id")]
		public long PingId { get; set; }

[Newtonsoft.Json.JsonProperty("disconnect_delay")]
		public int DisconnectDelay { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PingId);
			writer.Write(DisconnectDelay);

		}

		public void Deserialize(Reader reader)
		{
			PingId = reader.Read<long>();
			DisconnectDelay = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "ping_delay_disconnect";
		}
	}
}