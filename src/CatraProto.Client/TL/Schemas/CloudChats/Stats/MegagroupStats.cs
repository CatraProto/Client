using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MegagroupStats : MegagroupStatsBase
	{
		public static int ConstructorId { get; } = -276825834;
		public override StatsDateRangeDaysBase Period { get; set; }
		public override StatsAbsValueAndPrevBase Members { get; set; }
		public override StatsAbsValueAndPrevBase Messages { get; set; }
		public override StatsAbsValueAndPrevBase Viewers { get; set; }
		public override StatsAbsValueAndPrevBase Posters { get; set; }
		public override StatsGraphBase GrowthGraph { get; set; }
		public override StatsGraphBase MembersGraph { get; set; }
		public override StatsGraphBase NewMembersBySourceGraph { get; set; }
		public override StatsGraphBase LanguagesGraph { get; set; }
		public override StatsGraphBase MessagesGraph { get; set; }
		public override StatsGraphBase ActionsGraph { get; set; }
		public override StatsGraphBase TopHoursGraph { get; set; }
		public override StatsGraphBase WeekdaysGraph { get; set; }
		public override IList<StatsGroupTopPosterBase> TopPosters { get; set; }
		public override IList<StatsGroupTopAdminBase> TopAdmins { get; set; }
		public override IList<StatsGroupTopInviterBase> TopInviters { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Period);
			writer.Write(Members);
			writer.Write(Messages);
			writer.Write(Viewers);
			writer.Write(Posters);
			writer.Write(GrowthGraph);
			writer.Write(MembersGraph);
			writer.Write(NewMembersBySourceGraph);
			writer.Write(LanguagesGraph);
			writer.Write(MessagesGraph);
			writer.Write(ActionsGraph);
			writer.Write(TopHoursGraph);
			writer.Write(WeekdaysGraph);
			writer.Write(TopPosters);
			writer.Write(TopAdmins);
			writer.Write(TopInviters);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Period = reader.Read<StatsDateRangeDaysBase>();
			Members = reader.Read<StatsAbsValueAndPrevBase>();
			Messages = reader.Read<StatsAbsValueAndPrevBase>();
			Viewers = reader.Read<StatsAbsValueAndPrevBase>();
			Posters = reader.Read<StatsAbsValueAndPrevBase>();
			GrowthGraph = reader.Read<StatsGraphBase>();
			MembersGraph = reader.Read<StatsGraphBase>();
			NewMembersBySourceGraph = reader.Read<StatsGraphBase>();
			LanguagesGraph = reader.Read<StatsGraphBase>();
			MessagesGraph = reader.Read<StatsGraphBase>();
			ActionsGraph = reader.Read<StatsGraphBase>();
			TopHoursGraph = reader.Read<StatsGraphBase>();
			WeekdaysGraph = reader.Read<StatsGraphBase>();
			TopPosters = reader.ReadVector<StatsGroupTopPosterBase>();
			TopAdmins = reader.ReadVector<StatsGroupTopAdminBase>();
			TopInviters = reader.ReadVector<StatsGroupTopInviterBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}