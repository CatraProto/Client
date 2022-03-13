using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDhConfig : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 651135312; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }

[Newtonsoft.Json.JsonProperty("random_length")]
		public int RandomLength { get; set; }

        
        #nullable enable
 public GetDhConfig (int version,int randomLength)
{
 Version = version;
RandomLength = randomLength;
 
}
#nullable disable
                
        internal GetDhConfig() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Version);
			writer.Write(RandomLength);

		}

		public void Deserialize(Reader reader)
		{
			Version = reader.Read<int>();
			RandomLength = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.getDhConfig";
		}
	}
}