using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetChannelDifference : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Force = 1 << 0
		}

        public static int ConstructorId { get; } = 51854712;

		public int Flags { get; set; }
		public bool Force { get; set; }
		public InputChannelBase Channel { get; set; }
		public ChannelMessagesFilterBase Filter { get; set; }
		public int Pts { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{
			Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(Filter);
			writer.Write(Pts);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Force = FlagsHelper.IsFlagSet(Flags, 0);
			Channel = reader.Read<InputChannelBase>();
			Filter = reader.Read<ChannelMessagesFilterBase>();
			Pts = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}