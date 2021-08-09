using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnPublicKey : CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase
	{


        public static int StaticConstructorId { get => -914167110; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dc_id")]
		public override int DcId { get; set; }

[JsonPropertyName("public_key")]
		public override string PublicKey { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(PublicKey);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			PublicKey = reader.Read<string>();

		}
	}
}