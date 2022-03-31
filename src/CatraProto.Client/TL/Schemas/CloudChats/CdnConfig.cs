using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class CdnConfig : CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1462101002; }
        
[Newtonsoft.Json.JsonProperty("public_keys")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> PublicKeys { get; set; }


        #nullable enable
 public CdnConfig (IList<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> publicKeys)
{
 PublicKeys = publicKeys;
 
}
#nullable disable
        internal CdnConfig() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PublicKeys);

		}

		public override void Deserialize(Reader reader)
		{
			PublicKeys = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase>();

		}
		
		public override string ToString()
		{
		    return "cdnConfig";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}