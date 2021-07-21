using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqDHParams : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -686627650; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("nonce")]
		public System.Numerics.BigInteger Nonce { get; set; }

[JsonPropertyName("server_nonce")]
		public System.Numerics.BigInteger ServerNonce { get; set; }

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
			var sizeNonce = Nonce.GetByteCount();
			if(sizeNonce != 16){
				throw new CatraProto.TL.Exceptions.SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(Nonce);
			var sizeServerNonce = ServerNonce.GetByteCount();
			if(sizeServerNonce != 16){
				throw new CatraProto.TL.Exceptions.SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes", CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
			}
			writer.Write(ServerNonce);
			writer.Write(P);
			writer.Write(Q);
			writer.Write(PublicKeyFingerprint);
			writer.Write(EncryptedData);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);
			ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
			P = reader.Read<byte[]>();
			Q = reader.Read<byte[]>();
			PublicKeyFingerprint = reader.Read<long>();
			EncryptedData = reader.Read<byte[]>();

		}
	}
}