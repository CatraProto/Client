using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MegagroupStats : MegagroupStatsBase
	{


        public static int StaticConstructorId { get => -276825834; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("period")]
		public override StatsDateRangeDaysBase Period { get; set; }

[JsonPropertyName("members")]
		public override StatsAbsValueAndPrevBase Members { get; set; }

[JsonPropertyName("messages")]
		public override StatsAbsValueAndPrevBase Messages { get; set; }

[JsonPropertyName("viewers")]
		public override StatsAbsValueAndPrevBase Viewers { get; set; }

[JsonPropertyName("posters")]
		public override StatsAbsValueAndPrevBase Posters { get; set; }

[JsonPropertyName("growth_graph")]
		public override StatsGraphBase GrowthGraph { get; set; }

[JsonPropertyName("members_graph")]
		public override StatsGraphBase MembersGraph { get; set; }

[JsonPropertyName("new_members_by_source_graph")]
		public override StatsGraphBase NewMembersBySourceGraph { get; set; }

[JsonPropertyName("languages_graph")]
		public override StatsGraphBase LanguagesGraph { get; set; }

[JsonPropertyName("messages_graph")]
		public override StatsGraphBase MessagesGraph { get; set; }

[JsonPropertyName("actions_graph")]
		public override StatsGraphBase ActionsGraph { get; set; }

[JsonPropertyName("top_hours_graph")]
		public override StatsGraphBase TopHoursGraph { get; set; }

[JsonPropertyName("weekdays_graph")]
		public override StatsGraphBase WeekdaysGraph { get; set; }

[JsonPropertyName("top_posters")]
		public override IList<StatsGroupTopPosterBase> TopPosters { get; set; }

[JsonPropertyName("top_admins")]
		public override IList<StatsGroupTopAdminBase> TopAdmins { get; set; }

[JsonPropertyName("top_inviters")]
		public override IList<StatsGroupTopInviterBase> TopInviters { get; set; }

[JsonPropertyName("users")]
		public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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