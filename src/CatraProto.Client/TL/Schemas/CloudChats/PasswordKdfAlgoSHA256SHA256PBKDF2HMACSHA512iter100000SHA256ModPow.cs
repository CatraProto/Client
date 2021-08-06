using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase
	{


        public static int StaticConstructorId { get => 982592842; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("salt1")]
		public byte[] Salt1 { get; set; }

[JsonPropertyName("salt2")]
		public byte[] Salt2 { get; set; }

[JsonPropertyName("g")]
		public int G { get; set; }

[JsonPropertyName("p")]
		public byte[] P { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Salt1);
			writer.Write(Salt2);
			writer.Write(G);
			writer.Write(P);

		}

		public override void Deserialize(Reader reader)
		{
			Salt1 = reader.Read<byte[]>();
			Salt2 = reader.Read<byte[]>();
			G = reader.Read<int>();
			P = reader.Read<byte[]>();

		}
	}
}