using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaDocument : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum
		{
			TtlSeconds = 1 << 0
		}

		public static int ConstructorId { get; } = 598418386;
		public int Flags { get; set; }
		public InputDocumentBase Id { get; set; }
		public int? TtlSeconds { get; set; }

		public override void UpdateFlags()
		{
			Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TtlSeconds.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<InputDocumentBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				TtlSeconds = reader.Read<int>();
			}
		}
	}
}