using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class BindAuthKeyInner : CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInnerBase
	{


        public static int StaticConstructorId { get => 1973679973; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("nonce")]
		public override long Nonce { get; set; }

[JsonPropertyName("temp_auth_key_id")]
		public override long TempAuthKeyId { get; set; }

[JsonPropertyName("perm_auth_key_id")]
		public override long PermAuthKeyId { get; set; }

[JsonPropertyName("temp_session_id")]
		public override long TempSessionId { get; set; }

[JsonPropertyName("expires_at")]
		public override int ExpiresAt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Nonce);
			writer.Write(TempAuthKeyId);
			writer.Write(PermAuthKeyId);
			writer.Write(TempSessionId);
			writer.Write(ExpiresAt);

		}

		public override void Deserialize(Reader reader)
		{
			Nonce = reader.Read<long>();
			TempAuthKeyId = reader.Read<long>();
			PermAuthKeyId = reader.Read<long>();
			TempSessionId = reader.Read<long>();
			ExpiresAt = reader.Read<int>();

		}
	}
}