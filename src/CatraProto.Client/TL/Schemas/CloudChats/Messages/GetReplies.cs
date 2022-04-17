using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetReplies : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 584962828; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

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
 public GetReplies (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int msgId,int offsetId,int offsetDate,int addOffset,int limit,int maxId,int minId,long hash)
{
 Peer = peer;
MsgId = msgId;
OffsetId = offsetId;
OffsetDate = offsetDate;
AddOffset = addOffset;
Limit = limit;
MaxId = maxId;
MinId = minId;
Hash = hash;
 
}
#nullable disable
                
        internal GetReplies() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}
writer.WriteInt32(MsgId);
writer.WriteInt32(OffsetId);
writer.WriteInt32(OffsetDate);
writer.WriteInt32(AddOffset);
writer.WriteInt32(Limit);
writer.WriteInt32(MaxId);
writer.WriteInt32(MinId);
writer.WriteInt64(Hash);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var trymsgId = reader.ReadInt32();
if(trymsgId.IsError){
return ReadResult<IObject>.Move(trymsgId);
}
MsgId = trymsgId.Value;
			var tryoffsetId = reader.ReadInt32();
if(tryoffsetId.IsError){
return ReadResult<IObject>.Move(tryoffsetId);
}
OffsetId = tryoffsetId.Value;
			var tryoffsetDate = reader.ReadInt32();
if(tryoffsetDate.IsError){
return ReadResult<IObject>.Move(tryoffsetDate);
}
OffsetDate = tryoffsetDate.Value;
			var tryaddOffset = reader.ReadInt32();
if(tryaddOffset.IsError){
return ReadResult<IObject>.Move(tryaddOffset);
}
AddOffset = tryaddOffset.Value;
			var trylimit = reader.ReadInt32();
if(trylimit.IsError){
return ReadResult<IObject>.Move(trylimit);
}
Limit = trylimit.Value;
			var trymaxId = reader.ReadInt32();
if(trymaxId.IsError){
return ReadResult<IObject>.Move(trymaxId);
}
MaxId = trymaxId.Value;
			var tryminId = reader.ReadInt32();
if(tryminId.IsError){
return ReadResult<IObject>.Move(tryminId);
}
MinId = tryminId.Value;
			var tryhash = reader.ReadInt64();
if(tryhash.IsError){
return ReadResult<IObject>.Move(tryhash);
}
Hash = tryhash.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.getReplies";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}