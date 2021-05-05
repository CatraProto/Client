using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageService : MessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Out = 1 << 1,
			Mentioned = 1 << 4,
			MediaUnread = 1 << 5,
			Silent = 1 << 13,
			Post = 1 << 14,
			Legacy = 1 << 19,
			FromId = 1 << 8,
			ReplyTo = 1 << 3
		}

        public static int ConstructorId { get; } = 678405636;
		public int Flags { get; set; }
		public bool Out { get; set; }
		public bool Mentioned { get; set; }
		public bool MediaUnread { get; set; }
		public bool Silent { get; set; }
		public bool Post { get; set; }
		public bool Legacy { get; set; }
		public override int Id { get; set; }
		public PeerBase FromId { get; set; }
		public PeerBase PeerId { get; set; }
		public MessageReplyHeaderBase ReplyTo { get; set; }
		public int Date { get; set; }
		public MessageActionBase Action { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
			Flags = Post ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
			Flags = Legacy ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
			Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				writer.Write(FromId);
			}

			writer.Write(PeerId);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ReplyTo);
			}

			writer.Write(Date);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Out = FlagsHelper.IsFlagSet(Flags, 1);
			Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
			MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
			Silent = FlagsHelper.IsFlagSet(Flags, 13);
			Post = FlagsHelper.IsFlagSet(Flags, 14);
			Legacy = FlagsHelper.IsFlagSet(Flags, 19);
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 8))
			{
				FromId = reader.Read<PeerBase>();
			}

			PeerId = reader.Read<PeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ReplyTo = reader.Read<MessageReplyHeaderBase>();
			}

			Date = reader.Read<int>();
			Action = reader.Read<MessageActionBase>();

		}
	}
}