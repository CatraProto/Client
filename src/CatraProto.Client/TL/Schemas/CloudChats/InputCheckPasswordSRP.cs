using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputCheckPasswordSRP : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
	{


        public static int StaticConstructorId { get => -763367294; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("srp_id")]
		public long SrpId { get; set; }

[JsonPropertyName("A")]
		public byte[] A { get; set; }

[JsonPropertyName("M1")]
		public byte[] M1 { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(SrpId);
			writer.Write(A);
			writer.Write(M1);

		}

		public override void Deserialize(Reader reader)
		{
			SrpId = reader.Read<long>();
			A = reader.Read<byte[]>();
			M1 = reader.Read<byte[]>();

		}
	}
}