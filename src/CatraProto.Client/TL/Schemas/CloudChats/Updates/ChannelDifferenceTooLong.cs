using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class ChannelDifferenceTooLong : ChannelDifferenceBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Final = 1 << 0,
			Timeout = 1 << 1
		}

        public static int ConstructorId { get; } = -1531132162;
		public int Flags { get; set; }
		public override bool Final { get; set; }
		public override int? Timeout { get; set; }
		public DialogBase Dialog { get; set; }
		public IList<MessageBase> Messages { get; set; }
		public IList<ChatBase> Chats { get; set; }
		public IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Final ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Timeout.Value);
			}

			writer.Write(Dialog);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Final = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Timeout = reader.Read<int>();
			}

			Dialog = reader.Read<DialogBase>();
			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}