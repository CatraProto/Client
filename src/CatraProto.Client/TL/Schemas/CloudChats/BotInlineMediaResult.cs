using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMediaResult : BotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Photo = 1 << 0,
			Document = 1 << 1,
			Title = 1 << 1,
			Description = 1 << 2
		}

		public static int ConstructorId { get; } = 400266251;
		public int Flags { get; set; }
		public override string Id { get; set; }
		public override string Type { get; set; }
		public PhotoBase Photo { get; set; }
		public DocumentBase Document { get; set; }
		public override string Title { get; set; }
		public override string Description { get; set; }
		public override BotInlineMessageBase SendMessage { get; set; }

		public override void UpdateFlags()
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Type);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Photo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Document);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Title);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Description);
			}

			writer.Write(SendMessage);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Photo = reader.Read<PhotoBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Document = reader.Read<DocumentBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Title = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Description = reader.Read<string>();
			}

			SendMessage = reader.Read<BotInlineMessageBase>();
		}
	}
}