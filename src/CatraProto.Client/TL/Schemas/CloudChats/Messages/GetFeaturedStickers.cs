using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetFeaturedStickers : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1685588756; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

        
        #nullable enable
 public GetFeaturedStickers (long hash)
{
 Hash = hash;
 
}
#nullable disable
                
        internal GetFeaturedStickers() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();

		}

		public override string ToString()
		{
		    return "messages.getFeaturedStickers";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}