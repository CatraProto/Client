using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageReplies : MessageRepliesBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Comments = 1 << 0,
			RecentRepliers = 1 << 1,
			ChannelId = 1 << 0,
			MaxId = 1 << 2,
			ReadMaxId = 1 << 3
		}

		public static int ConstructorId { get; } = 1093204652;
		public int Flags { get; set; }
		public override bool Comments { get; set; }
		public override int Replies { get; set; }
		public override int RepliesPts { get; set; }
		public override IList<PeerBase> RecentRepliers { get; set; }
		public override int? ChannelId { get; set; }
		public override int? MaxId { get; set; }
		public override int? ReadMaxId { get; set; }

		public override void UpdateFlags()
		{
			Flags = Comments ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = RecentRepliers == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ChannelId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ReadMaxId == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Replies);
			writer.Write(RepliesPts);
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(RecentRepliers);
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ChannelId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(MaxId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ReadMaxId.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Comments = FlagsHelper.IsFlagSet(Flags, 0);
			Replies = reader.Read<int>();
			RepliesPts = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				RecentRepliers = reader.ReadVector<PeerBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				ChannelId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				MaxId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReadMaxId = reader.Read<int>();
			}
		}
	}
}