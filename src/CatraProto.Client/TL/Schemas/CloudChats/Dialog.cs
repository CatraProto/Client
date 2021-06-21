using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Dialog : DialogBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pinned = 1 << 2,
			UnreadMark = 1 << 3,
			Pts = 1 << 0,
			Draft = 1 << 1,
			FolderId = 1 << 4
		}

        public static int ConstructorId { get; } = 739712882;
		public int Flags { get; set; }
		public override bool Pinned { get; set; }
		public bool UnreadMark { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public override int TopMessage { get; set; }
		public int ReadInboxMaxId { get; set; }
		public int ReadOutboxMaxId { get; set; }
		public int UnreadCount { get; set; }
		public int UnreadMentionsCount { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }
		public int? Pts { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase Draft { get; set; }
		public int? FolderId { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = UnreadMark ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Pts == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Draft == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(TopMessage);
			writer.Write(ReadInboxMaxId);
			writer.Write(ReadOutboxMaxId);
			writer.Write(UnreadCount);
			writer.Write(UnreadMentionsCount);
			writer.Write(NotifySettings);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Pts.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Draft);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(FolderId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Pinned = FlagsHelper.IsFlagSet(Flags, 2);
			UnreadMark = FlagsHelper.IsFlagSet(Flags, 3);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			TopMessage = reader.Read<int>();
			ReadInboxMaxId = reader.Read<int>();
			ReadOutboxMaxId = reader.Read<int>();
			UnreadCount = reader.Read<int>();
			UnreadMentionsCount = reader.Read<int>();
			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Pts = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Draft = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				FolderId = reader.Read<int>();
			}


		}
	}
}