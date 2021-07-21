using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class ConfirmCall : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 788404002; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

[JsonPropertyName("g_a")]
		public byte[] GA { get; set; }

[JsonPropertyName("key_fingerprint")]
		public long KeyFingerprint { get; set; }

[JsonPropertyName("protocol")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GA);
			writer.Write(KeyFingerprint);
			writer.Write(Protocol);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			GA = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();

		}
	}
}