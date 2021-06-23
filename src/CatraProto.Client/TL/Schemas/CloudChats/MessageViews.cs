using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageViews : MessageViewsBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Views = 1 << 0,
			Forwards = 1 << 1,
			Replies = 1 << 2
		}

		public static int ConstructorId { get; } = 1163625789;
		public int Flags { get; set; }
		public override int? Views { get; set; }
		public override int? Forwards { get; set; }
		public override MessageRepliesBase Replies { get; set; }

		public override void UpdateFlags()
		{
			Flags = Views == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Forwards == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Replies == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Views.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Forwards.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Replies);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Views = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Forwards = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Replies = reader.Read<MessageRepliesBase>();
			}
		}
	}
}