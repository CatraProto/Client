using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ToggleDialogPin : IMethod<bool>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pinned = 1 << 0
		}

        public static int ConstructorId { get; } = -1489903017;

		public int Flags { get; set; }
		public bool Pinned { get; set; }
		public InputDialogPeerBase Peer { get; set; }

		public void UpdateFlags() 
		{
			Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

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
			Pinned = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputDialogPeerBase>();

		}
	}
}