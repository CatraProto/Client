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
		public sealed override int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("public_key")]
		public sealed override string PublicKey { get; set; }


        #nullable enable
 public CdnPublicKey (int dcId,string publicKey)
{
 DcId = dcId;
PublicKey = publicKey;
 
}
#nullable disable
        internal CdnPublicKey() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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