using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadHistoryInbox : UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 0
		}

        public static int StaticConstructorId { get => -1667805217; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("folder_id")]
		public int? FolderId { get; set; }

[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("max_id")]
		public int MaxId { get; set; }

[JsonPropertyName("still_unread_count")]
		public int StillUnreadCount { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(Peer);
			writer.Write(MaxId);
			writer.Write(StillUnreadCount);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FolderId = reader.Read<int>();
			}

			Peer = reader.Read<PeerBase>();
			MaxId = reader.Read<int>();
			StillUnreadCount = reader.Read<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}