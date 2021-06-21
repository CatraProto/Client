using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdatePinnedMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Silent = 1 << 0,
			Unpin = 1 << 1,
			PmOneside = 1 << 2
		}

		public static int ConstructorId { get; } = -760547348;
		public int Flags { get; set; }
		public bool Silent { get; set; }
		public bool Unpin { get; set; }
		public bool PmOneside { get; set; }
		public InputPeerBase Peer { get; set; }
		public int Id { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Unpin ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = PmOneside ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Unpin = FlagsHelper.IsFlagSet(Flags, 1);
			PmOneside = FlagsHelper.IsFlagSet(Flags, 2);
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
		}
	}
}