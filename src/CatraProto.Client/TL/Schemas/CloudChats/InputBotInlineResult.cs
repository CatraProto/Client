using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResult : InputBotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Title = 1 << 1,
			Description = 1 << 2,
			Url = 1 << 3,
			Thumb = 1 << 4,
			Content = 1 << 5
		}

		public static int ConstructorId { get; } = -2000710887;
		public int Flags { get; set; }
		public override string Id { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Url { get; set; }
		public InputWebDocumentBase Thumb { get; set; }
		public InputWebDocumentBase Content { get; set; }
		public override InputBotInlineMessageBase SendMessage { get; set; }

		public override void UpdateFlags()
		{
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = Content == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Type);
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Title);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Description);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Url);
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Thumb);
			}

			if (FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(Content);
			}

			writer.Write(SendMessage);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				Title = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				Description = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Url = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				Thumb = reader.Read<InputWebDocumentBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 5))
			{
				Content = reader.Read<InputWebDocumentBase>();
			}

			SendMessage = reader.Read<InputBotInlineMessageBase>();
		}
	}
}