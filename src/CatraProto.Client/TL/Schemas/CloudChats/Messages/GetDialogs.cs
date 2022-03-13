using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDialogs : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludePinned = 1 << 0,
			FolderId = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1594569905; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("exclude_pinned")]
		public bool ExcludePinned { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_date")]
		public int OffsetDate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id")]
		public int OffsetId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

        
        #nullable enable
 public GetDialogs (int offsetDate,int offsetId,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer,int limit,long hash)
{
 OffsetDate = offsetDate;
OffsetId = offsetId;
OffsetPeer = offsetPeer;
Limit = limit;
Hash = hash;
 
}
#nullable disable
                
        internal GetDialogs() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = ExcludePinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(OffsetDate);
			writer.Write(OffsetId);
			writer.Write(OffsetPeer);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ExcludePinned = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				FolderId = reader.Read<int>();
			}

			OffsetDate = reader.Read<int>();
			OffsetId = reader.Read<int>();
			OffsetPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Limit = reader.Read<int>();
			Hash = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messages.getDialogs";
		}
	}
}