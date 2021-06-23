using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShortMessage : UpdatesBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Out = 1 << 1,
			Mentioned = 1 << 4,
			MediaUnread = 1 << 5,
			Silent = 1 << 13,
			FwdFrom = 1 << 2,
			ViaBotId = 1 << 11,
			ReplyTo = 1 << 3,
			Entities = 1 << 7
		}

		public static int ConstructorId { get; } = 580309704;
		public int Flags { get; set; }
		public bool Out { get; set; }
		public bool Mentioned { get; set; }
		public bool MediaUnread { get; set; }
		public bool Silent { get; set; }
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Message { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }
		public int Date { get; set; }
		public MessageFwdHeaderBase FwdFrom { get; set; }
		public int? ViaBotId { get; set; }
		public MessageReplyHeaderBase ReplyTo { get; set; }
		public IList<MessageEntityBase> Entities { get; set; }

		public override void UpdateFlags()
		{
			Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = FwdFrom == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = ViaBotId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
			Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
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
			writer.Write(UserId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Date);
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(FwdFrom);
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(ViaBotId.Value);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ReplyTo);
			}

			if (FlagsHelper.IsFlagSet(Flags, 7))
			{
				writer.Write(Entities);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Out = FlagsHelper.IsFlagSet(Flags, 1);
			Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
			MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
			Silent = FlagsHelper.IsFlagSet(Flags, 13);
			Id = reader.Read<int>();
			UserId = reader.Read<int>();
			Message = reader.Read<string>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Date = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				FwdFrom = reader.Read<MessageFwdHeaderBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 11))
			{
				ViaBotId = reader.Read<int>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReplyTo = reader.Read<MessageReplyHeaderBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 7))
			{
				Entities = reader.ReadVector<MessageEntityBase>();
			}
		}
	}
}