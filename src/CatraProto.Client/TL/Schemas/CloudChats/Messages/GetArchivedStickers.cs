using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetArchivedStickers : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Masks = 1 << 0
		}

		public static int ConstructorId { get; } = 1475442322;
		public int Flags { get; set; }
		public bool Masks { get; set; }
		public long OffsetId { get; set; }
		public int Limit { get; set; }

		public Type Type { get; init; } = typeof(ArchivedStickersBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(OffsetId);
			writer.Write(Limit);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			OffsetId = reader.Read<long>();
			Limit = reader.Read<int>();
		}
	}
}