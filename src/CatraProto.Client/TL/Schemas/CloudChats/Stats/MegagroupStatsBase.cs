using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MegagroupStatsBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Members { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Messages { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Viewers { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Posters { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MembersGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewMembersBySourceGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MessagesGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ActionsGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase WeekdaysGraph { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
