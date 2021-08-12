using System;
using System.Numerics;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqDHParams : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -686627650; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ServerDHParamsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("nonce")]
		public BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public BigInteger ServerNonce { get; set; }

[JsonPropertyName("p")]
		public byte[] P { get; set; }

[JsonPropertyName("q")]
		public byte[] Q { get; set; }

[JsonPropertyName("public_key_fingerprint")]
		public long PublicKeyFingerprint { get; set; }

[JsonPropertyName("encrypted_data")]
		public byte[] EncryptedData { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(ServerNonce);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(PublicKeyFingerprint);
			writer.Write(EncryptedData);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<BigInteger>(128);
			ServerNonce = reader.Read<BigInteger>(128);
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			PublicKeyFingerprint = reader.Read<long>();
			EncryptedData = reader.Read<byte[]>();
		}

		public override string ToString()
		{
			return "req_DH_params";
		}
	}
}