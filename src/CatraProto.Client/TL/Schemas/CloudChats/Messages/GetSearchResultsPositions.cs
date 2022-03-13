using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSearchResultsPositions : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1855292323; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("filter")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id")]
		public int OffsetId { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetSearchResultsPositions (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter,int offsetId,int limit)
{
 Peer = peer;
Filter = filter;
OffsetId = offsetId;
Limit = limit;
 
}
#nullable disable
                
        internal GetSearchResultsPositions() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Filter);
			writer.Write(OffsetId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.getSearchResultsPositions";
		}
	}
}