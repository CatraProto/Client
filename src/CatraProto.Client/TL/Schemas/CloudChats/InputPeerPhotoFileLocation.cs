using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerPhotoFileLocation : InputFileLocationBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Big = 1 << 0
		}

		public static int ConstructorId { get; } = 668375447;
		public int Flags { get; set; }
		public bool Big { get; set; }
		public InputPeerBase Peer { get; set; }
		public long VolumeId { get; set; }
		public int LocalId { get; set; }

		public override void UpdateFlags()
		{
			Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(VolumeId);
			writer.Write(LocalId);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Big = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputPeerBase>();
			VolumeId = reader.Read<long>();
			LocalId = reader.Read<int>();
		}
	}
}