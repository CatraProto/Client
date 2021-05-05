using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class BroadcastStats : BroadcastStatsBase
	{


        public static int ConstructorId { get; } = -1107852396;
		public override StatsDateRangeDaysBase Period { get; set; }
		public override StatsAbsValueAndPrevBase Followers { get; set; }
		public override StatsAbsValueAndPrevBase ViewsPerPost { get; set; }
		public override StatsAbsValueAndPrevBase SharesPerPost { get; set; }
		public override StatsPercentValueBase EnabledNotifications { get; set; }
		public override StatsGraphBase GrowthGraph { get; set; }
		public override StatsGraphBase FollowersGraph { get; set; }
		public override StatsGraphBase MuteGraph { get; set; }
		public override StatsGraphBase TopHoursGraph { get; set; }
		public override StatsGraphBase InteractionsGraph { get; set; }
		public override StatsGraphBase IvInteractionsGraph { get; set; }
		public override StatsGraphBase ViewsBySourceGraph { get; set; }
		public override StatsGraphBase NewFollowersBySourceGraph { get; set; }
		public override StatsGraphBase LanguagesGraph { get; set; }
		public override IList<MessageInteractionCountersBase> RecentMessageInteractions { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Period);
			writer.Write(Followers);
			writer.Write(ViewsPerPost);
			writer.Write(SharesPerPost);
			writer.Write(EnabledNotifications);
			writer.Write(GrowthGraph);
			writer.Write(FollowersGraph);
			writer.Write(MuteGraph);
			writer.Write(TopHoursGraph);
			writer.Write(InteractionsGraph);
			writer.Write(IvInteractionsGraph);
			writer.Write(ViewsBySourceGraph);
			writer.Write(NewFollowersBySourceGraph);
			writer.Write(LanguagesGraph);
			writer.Write(RecentMessageInteractions);

		}

		public override void Deserialize(Reader reader)
		{
			Period = reader.Read<StatsDateRangeDaysBase>();
			Followers = reader.Read<StatsAbsValueAndPrevBase>();
			ViewsPerPost = reader.Read<StatsAbsValueAndPrevBase>();
			SharesPerPost = reader.Read<StatsAbsValueAndPrevBase>();
			EnabledNotifications = reader.Read<StatsPercentValueBase>();
			GrowthGraph = reader.Read<StatsGraphBase>();
			FollowersGraph = reader.Read<StatsGraphBase>();
			MuteGraph = reader.Read<StatsGraphBase>();
			TopHoursGraph = reader.Read<StatsGraphBase>();
			InteractionsGraph = reader.Read<StatsGraphBase>();
			IvInteractionsGraph = reader.Read<StatsGraphBase>();
			ViewsBySourceGraph = reader.Read<StatsGraphBase>();
			NewFollowersBySourceGraph = reader.Read<StatsGraphBase>();
			LanguagesGraph = reader.Read<StatsGraphBase>();
			RecentMessageInteractions = reader.ReadVector<MessageInteractionCountersBase>();

		}
	}
}