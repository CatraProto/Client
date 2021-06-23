using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditInlineBotMessage : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			NoWebpage = 1 << 1,
			Message = 1 << 11,
			Media = 1 << 14,
			ReplyMarkup = 1 << 2,
			Entities = 1 << 3
		}

		public static int ConstructorId { get; } = -2091549254;
		public int Flags { get; set; }
		public bool NoWebpage { get; set; }
		public InputBotInlineMessageIDBase Id { get; set; }
		public string Message { get; set; }
		public InputMediaBase Media { get; set; }
		public ReplyMarkupBase ReplyMarkup { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = Media == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(Message);
			}

			if (FlagsHelper.IsFlagSet(Flags, 14))
			{
				writer.Write(Media);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Entities);
			}
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
			Id = reader.Read<InputBotInlineMessageIDBase>();
			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				Message = reader.Read<string>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 14))
			{
				Media = reader.Read<InputMediaBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<ReplyMarkupBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}
	}
}