using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalt : CatraProto.Client.TL.Schemas.MTProto.FutureSaltBase
	{


        public static int StaticConstructorId { get => 155834844; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("valid_since")]
		public override int ValidSince { get; set; }

[JsonPropertyName("valid_until")]
		public override int ValidUntil { get; set; }

[JsonPropertyName("salt")]
		public override long Salt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ValidSince);
			writer.Write(ValidUntil);
			writer.Write(Salt);

		}

		public override void Deserialize(Reader reader)
		{
			ValidSince = reader.Read<int>();
			ValidUntil = reader.Read<int>();
			Salt = reader.Read<long>();

		}
	}
}