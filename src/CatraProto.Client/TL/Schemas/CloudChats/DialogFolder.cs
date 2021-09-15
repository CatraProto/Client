using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFolder : CatraProto.Client.TL.Schemas.CloudChats.DialogBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pinned = 1 << 2
		}

        public static int StaticConstructorId { get => 1908216652; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("pinned")]
		public override bool Pinned { get; set; }

[Newtonsoft.Json.JsonProperty("folder")]
		public CatraProto.Client.TL.Schemas.CloudChats.FolderBase Folder { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("top_message")]
		public override int TopMessage { get; set; }

[Newtonsoft.Json.JsonProperty("unread_muted_peers_count")]
		public int UnreadMutedPeersCount { get; set; }

[Newtonsoft.Json.JsonProperty("unread_unmuted_peers_count")]
		public int UnreadUnmutedPeersCount { get; set; }

[Newtonsoft.Json.JsonProperty("unread_muted_messages_count")]
		public int UnreadMutedMessagesCount { get; set; }

[Newtonsoft.Json.JsonProperty("unread_unmuted_messages_count")]
		public int UnreadUnmutedMessagesCount { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Folder);
			writer.Write(Peer);
			writer.Write(TopMessage);
			writer.Write(UnreadMutedPeersCount);
			writer.Write(UnreadUnmutedPeersCount);
			writer.Write(UnreadMutedMessagesCount);
			writer.Write(UnreadUnmutedMessagesCount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pinned = FlagsHelper.IsFlagSet(Flags, 2);
			Folder = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.FolderBase>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			TopMessage = reader.Read<int>();
			UnreadMutedPeersCount = reader.Read<int>();
			UnreadUnmutedPeersCount = reader.Read<int>();
			UnreadMutedMessagesCount = reader.Read<int>();
			UnreadUnmutedMessagesCount = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "dialogFolder";
		}
	}
}