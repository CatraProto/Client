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


        public static int StaticConstructorId { get => -316748368; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public override byte[] Hash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}