using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class PingDelayDisconnect : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -213746804; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(PongBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("ping_id")]
		public long PingId { get; set; }

[JsonPropertyName("disconnect_delay")]
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
	}
}