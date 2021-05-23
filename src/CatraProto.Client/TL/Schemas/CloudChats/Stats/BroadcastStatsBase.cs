using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class BroadcastStatsBase : IObject
    {
		public abstract StatsDateRangeDaysBase Period { get; set; }
		public abstract StatsAbsValueAndPrevBase Followers { get; set; }
		public abstract StatsAbsValueAndPrevBase ViewsPerPost { get; set; }
		public abstract StatsAbsValueAndPrevBase SharesPerPost { get; set; }
		public abstract StatsPercentValueBase EnabledNotifications { get; set; }
		public abstract StatsGraphBase GrowthGraph { get; set; }
		public abstract StatsGraphBase FollowersGraph { get; set; }
		public abstract StatsGraphBase MuteGraph { get; set; }
		public abstract StatsGraphBase TopHoursGraph { get; set; }
		public abstract StatsGraphBase InteractionsGraph { get; set; }
		public abstract StatsGraphBase IvInteractionsGraph { get; set; }
		public abstract StatsGraphBase ViewsBySourceGraph { get; set; }
		public abstract StatsGraphBase NewFollowersBySourceGraph { get; set; }
		public abstract StatsGraphBase LanguagesGraph { get; set; }
		public abstract IList<MessageInteractionCountersBase> RecentMessageInteractions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
