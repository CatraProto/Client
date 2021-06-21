using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MarkDialogUnread : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Unread = 1 << 0
		}

		public static int ConstructorId { get; } = -1031349873;
		public int Flags { get; set; }
		public bool Unread { get; set; }
		public InputDialogPeerBase Peer { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Unread = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputDialogPeerBase>();
		}
	}
}