using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SaveDraft : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			NoWebpage = 1 << 1,
			ReplyToMsgId = 1 << 0,
			Entities = 1 << 3
		}

		public static int ConstructorId { get; } = -1137057461;
		public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public int? ReplyToMsgId { get; set; }
		public InputPeerBase Peer { get; set; }
		public string Message { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToMsgId.Value);
			}

			writer.Write(Peer);
			writer.Write(Message);
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToMsgId = reader.Read<int>();
			}

			Peer = reader.Read<InputPeerBase>();
			Message = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}
	}
}