using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class ChannelDifference : ChannelDifferenceBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Final = 1 << 0,
			Timeout = 1 << 1
		}

        public static int ConstructorId { get; } = 543450958;
		public int Flags { get; set; }
		public override bool Final { get; set; }
		public int Pts { get; set; }
		public override int? Timeout { get; set; }
		public IList<MessageBase> NewMessages { get; set; }
		public IList<UpdateBase> OtherUpdates { get; set; }
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
			writer.Write(Pts);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Timeout.Value);
			}

			writer.Write(NewMessages);
			writer.Write(OtherUpdates);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Final = FlagsHelper.IsFlagSet(Flags, 0);
			Pts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Timeout = reader.Read<int>();
			}

			NewMessages = reader.ReadVector<MessageBase>();
			OtherUpdates = reader.ReadVector<UpdateBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}