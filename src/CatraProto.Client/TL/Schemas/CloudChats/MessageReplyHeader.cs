using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageReplyHeader : MessageReplyHeaderBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyToPeerId = 1 << 0,
			ReplyToTopId = 1 << 1
		}

        public static int ConstructorId { get; } = -1495959709;
		public int Flags { get; set; }
		public override int ReplyToMsgId { get; set; }
		public override PeerBase ReplyToPeerId { get; set; }
		public override int? ReplyToTopId { get; set; }

		public override void UpdateFlags() 
		{
			Flags = ReplyToPeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReplyToTopId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ReplyToMsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReplyToPeerId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ReplyToTopId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ReplyToMsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReplyToPeerId = reader.Read<PeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ReplyToTopId = reader.Read<int>();
			}


		}
	}
}