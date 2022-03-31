using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueHash : CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -316748368; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public sealed override byte[] Hash { get; set; }


        #nullable enable
 public SecureValueHash (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type,byte[] hash)
{
 Type = type;
Hash = hash;
 
}
#nullable disable
        internal SecureValueHash() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Hash);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			Hash = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "secureValueHash";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}