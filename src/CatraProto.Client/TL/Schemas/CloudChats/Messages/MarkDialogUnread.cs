using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MarkDialogUnread : IMethod<bool>
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

		public void UpdateFlags() 
		{
			Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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