using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelMessagesFilter : ChannelMessagesFilterBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ExcludeNewMessages = 1 << 1
		}

        public static int ConstructorId { get; } = -847783593;
		public int Flags { get; set; }
		public bool ExcludeNewMessages { get; set; }
		public IList<MessageRangeBase> Ranges { get; set; }

		public override void UpdateFlags() 
		{
			Flags = ExcludeNewMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Ranges);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ExcludeNewMessages = FlagsHelper.IsFlagSet(Flags, 1);
			Ranges = reader.ReadVector<MessageRangeBase>();

		}
	}
}