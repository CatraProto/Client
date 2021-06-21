using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetAdminLog : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EventsFilter = 1 << 0,
			Admins = 1 << 1
		}

        public static int ConstructorId { get; } = 870184064;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }
		public string Q { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase EventsFilter { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Admins { get; set; }
		public long MaxId { get; set; }
		public long MinId { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{
			Flags = EventsFilter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Admins == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(Q);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(EventsFilter);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Admins);
			}

			writer.Write(MaxId);
			writer.Write(MinId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			Q = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				EventsFilter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Admins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			}

			MaxId = reader.Read<long>();
			MinId = reader.Read<long>();
			Limit = reader.Read<int>();

		}
	}
}