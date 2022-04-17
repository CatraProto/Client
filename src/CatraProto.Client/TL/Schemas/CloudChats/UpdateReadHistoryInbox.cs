using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadHistoryInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1667805217; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public int MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("still_unread_count")]
		public int StillUnreadCount { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateReadHistoryInbox (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int maxId,int stillUnreadCount,int pts,int ptsCount)
{
 Peer = peer;
MaxId = maxId;
StillUnreadCount = stillUnreadCount;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateReadHistoryInbox() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
writer.WriteInt32(FolderId.Value);
			}

var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}
writer.WriteInt32(MaxId);
writer.WriteInt32(StillUnreadCount);
writer.WriteInt32(Pts);
writer.WriteInt32(PtsCount);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryfolderId = reader.ReadInt32();
if(tryfolderId.IsError){
return ReadResult<IObject>.Move(tryfolderId);
}
FolderId = tryfolderId.Value;
			}

			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var trymaxId = reader.ReadInt32();
if(trymaxId.IsError){
return ReadResult<IObject>.Move(trymaxId);
}
MaxId = trymaxId.Value;
			var trystillUnreadCount = reader.ReadInt32();
if(trystillUnreadCount.IsError){
return ReadResult<IObject>.Move(trystillUnreadCount);
}
StillUnreadCount = trystillUnreadCount.Value;
			var trypts = reader.ReadInt32();
if(trypts.IsError){
return ReadResult<IObject>.Move(trypts);
}
Pts = trypts.Value;
			var tryptsCount = reader.ReadInt32();
if(tryptsCount.IsError){
return ReadResult<IObject>.Move(tryptsCount);
}
PtsCount = tryptsCount.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateReadHistoryInbox";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}