using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFolder : DialogBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Pinned = 1 << 2
		}

		public static int ConstructorId { get; } = 1908216652;
		public int Flags { get; set; }
		public override bool Pinned { get; set; }
		public FolderBase Folder { get; set; }
		public override PeerBase Peer { get; set; }
		public override int TopMessage { get; set; }
		public int UnreadMutedPeersCount { get; set; }
		public int UnreadUnmutedPeersCount { get; set; }
		public int UnreadMutedMessagesCount { get; set; }
		public int UnreadUnmutedMessagesCount { get; set; }

		public override void UpdateFlags()
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

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
			Folder = reader.Read<FolderBase>();
			Peer = reader.Read<PeerBase>();
			TopMessage = reader.Read<int>();
			UnreadMutedPeersCount = reader.Read<int>();
			UnreadUnmutedPeersCount = reader.Read<int>();
			UnreadMutedMessagesCount = reader.Read<int>();
			UnreadUnmutedMessagesCount = reader.Read<int>();
		}
	}
}