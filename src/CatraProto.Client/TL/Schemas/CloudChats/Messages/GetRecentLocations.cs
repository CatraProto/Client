using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetRecentLocations : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1881817312; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

        
        #nullable enable
 public GetRecentLocations (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int limit,long hash)
{
 Peer = peer;
Limit = limit;
Hash = hash;
 
}
#nullable disable
                
        internal GetRecentLocations() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Limit = reader.Read<int>();
			Hash = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messages.getRecentLocations";
		}
	}
}