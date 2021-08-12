using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class AcceptCall : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1003664544; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(PhoneCallBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("peer")]
		public InputPhoneCallBase Peer { get; set; }

[JsonPropertyName("g_b")]
		public byte[] GB { get; set; }

[JsonPropertyName("protocol")]
		public PhoneCallProtocolBase Protocol { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GB);
			writer.Write(Protocol);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPhoneCallBase>();
			GB = reader.Read<byte[]>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
		}

		public override string ToString()
		{
			return "phone.acceptCall";
		}
	}
}