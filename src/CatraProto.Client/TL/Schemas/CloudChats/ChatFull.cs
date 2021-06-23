using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatFull : ChatFullBase
	{
		[Flags]
		public enum FlagsEnum
		{
			CanSetUsername = 1 << 7,
			HasScheduled = 1 << 8,
			ChatPhoto = 1 << 2,
			BotInfo = 1 << 3,
			PinnedMsgId = 1 << 6,
			FolderId = 1 << 11
		}

		public static int ConstructorId { get; } = 461151667;
		public int Flags { get; set; }
		public override bool CanSetUsername { get; set; }
		public override bool HasScheduled { get; set; }
		public override int Id { get; set; }
		public override string About { get; set; }
		public ChatParticipantsBase Participants { get; set; }
		public override PhotoBase ChatPhoto { get; set; }
		public override PeerNotifySettingsBase NotifySettings { get; set; }
		public override ExportedChatInviteBase ExportedInvite { get; set; }
		public override IList<BotInfoBase> BotInfo { get; set; }
		public override int? PinnedMsgId { get; set; }
		public override int? FolderId { get; set; }

		public override void UpdateFlags()
		{
			Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = ChatPhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(About);
			writer.Write(Participants);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ChatPhoto);
			}

			writer.Write(NotifySettings);
			writer.Write(ExportedInvite);
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BotInfo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PinnedMsgId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanSetUsername = FlagsHelper.IsFlagSet(Flags, 7);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 8);
			Id = reader.Read<int>();
			About = reader.Read<string>();
			Participants = reader.Read<ChatParticipantsBase>();
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				ChatPhoto = reader.Read<PhotoBase>();
			}

			NotifySettings = reader.Read<PeerNotifySettingsBase>();
			ExportedInvite = reader.Read<ExportedChatInviteBase>();
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				BotInfo = reader.ReadVector<BotInfoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				PinnedMsgId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}
		}
	}
}