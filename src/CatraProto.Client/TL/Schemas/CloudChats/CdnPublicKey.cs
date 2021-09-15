using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnPublicKey : CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase
	{


        public static int StaticConstructorId { get => -914167110; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("dc_id")]
		public override int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("public_key")]
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
				
		public override string ToString()
		{
		    return "cdnPublicKey";
		}
	}
}