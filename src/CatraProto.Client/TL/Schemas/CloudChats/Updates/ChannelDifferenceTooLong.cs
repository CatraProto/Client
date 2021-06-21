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
		public CatraProto.Client.TL.Schemas.CloudChats.DialogBase Dialog { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

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

			Dialog = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>();
			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}