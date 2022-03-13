using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetHistory : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1143203525; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id")]
		public int OffsetId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_date")]
		public int OffsetDate { get; set; }

[Newtonsoft.Json.JsonProperty("add_offset")]
		public int AddOffset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public int MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("min_id")]
		public int MinId { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

        
        #nullable enable
 public GetHistory (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int offsetId,int offsetDate,int addOffset,int limit,int maxId,int minId,long hash)
{
 Peer = peer;
OffsetId = offsetId;
OffsetDate = offsetDate;
AddOffset = addOffset;
Limit = limit;
MaxId = maxId;
MinId = minId;
Hash = hash;
 
}
#nullable disable
                
        internal GetHistory() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(OffsetId);
			writer.Write(OffsetDate);
			writer.Write(AddOffset);
			writer.Write(Limit);
			writer.Write(MaxId);
			writer.Write(MinId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			OffsetId = reader.Read<int>();
			OffsetDate = reader.Read<int>();
			AddOffset = reader.Read<int>();
			Limit = reader.Read<int>();
			MaxId = reader.Read<int>();
			MinId = reader.Read<int>();
			Hash = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messages.getHistory";
		}
	}
}