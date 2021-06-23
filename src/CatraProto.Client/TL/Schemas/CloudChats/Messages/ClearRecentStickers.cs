using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ClearRecentStickers : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Attached = 1 << 0
		}

		public static int ConstructorId { get; } = -1986437075;
		public int Flags { get; set; }
		public bool Attached { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Attached = FlagsHelper.IsFlagSet(Flags, 0);
		}
	}
}