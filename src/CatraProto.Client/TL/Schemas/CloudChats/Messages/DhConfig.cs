using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DhConfig : CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 740433629; }
        
[Newtonsoft.Json.JsonProperty("g")]
		public int G { get; set; }

[Newtonsoft.Json.JsonProperty("p")]
		public byte[] P { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }

[Newtonsoft.Json.JsonProperty("random")]
		public sealed override byte[] Random { get; set; }


        #nullable enable
 public DhConfig (int g,byte[] p,int version,byte[] random)
{
 G = g;
P = p;
Version = version;
Random = random;
 
}
#nullable disable
        internal DhConfig() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(G);
			writer.Write(P);
			writer.Write(Version);
			writer.Write(Random);

		}

		public override void Deserialize(Reader reader)
		{
			G = reader.Read<int>();
			P = reader.Read<byte[]>();
			Version = reader.Read<int>();
			Random = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "messages.dhConfig";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}