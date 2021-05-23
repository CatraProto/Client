using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MegagroupStatsBase : IObject
    {
		public abstract StatsDateRangeDaysBase Period { get; set; }
		public abstract StatsAbsValueAndPrevBase Members { get; set; }
		public abstract StatsAbsValueAndPrevBase Messages { get; set; }
		public abstract StatsAbsValueAndPrevBase Viewers { get; set; }
		public abstract StatsAbsValueAndPrevBase Posters { get; set; }
		public abstract StatsGraphBase GrowthGraph { get; set; }
		public abstract StatsGraphBase MembersGraph { get; set; }
		public abstract StatsGraphBase NewMembersBySourceGraph { get; set; }
		public abstract StatsGraphBase LanguagesGraph { get; set; }
		public abstract StatsGraphBase MessagesGraph { get; set; }
		public abstract StatsGraphBase ActionsGraph { get; set; }
		public abstract StatsGraphBase TopHoursGraph { get; set; }
		public abstract StatsGraphBase WeekdaysGraph { get; set; }
		public abstract IList<StatsGroupTopPosterBase> TopPosters { get; set; }
		public abstract IList<StatsGroupTopAdminBase> TopAdmins { get; set; }
		public abstract IList<StatsGroupTopInviterBase> TopInviters { get; set; }
		public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
