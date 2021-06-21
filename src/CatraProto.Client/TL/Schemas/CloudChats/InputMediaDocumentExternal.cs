using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaDocumentExternal : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum
		{
			TtlSeconds = 1 << 0
		}

		public static int ConstructorId { get; } = -78455655;
		public int Flags { get; set; }
		public string Url { get; set; }
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
			writer.Write(Url);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TtlSeconds.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Url = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				TtlSeconds = reader.Read<int>();
			}
		}
	}
}