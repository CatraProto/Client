using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MegagroupStatsBase : IObject
    {

[JsonPropertyName("period")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

[JsonPropertyName("members")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Members { get; set; }

[JsonPropertyName("messages")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Messages { get; set; }

[JsonPropertyName("viewers")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Viewers { get; set; }

[JsonPropertyName("posters")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Posters { get; set; }

[JsonPropertyName("growth_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

[JsonPropertyName("members_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MembersGraph { get; set; }

[JsonPropertyName("new_members_by_source_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewMembersBySourceGraph { get; set; }

[JsonPropertyName("languages_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

[JsonPropertyName("messages_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MessagesGraph { get; set; }

[JsonPropertyName("actions_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ActionsGraph { get; set; }

[JsonPropertyName("top_hours_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

[JsonPropertyName("weekdays_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase WeekdaysGraph { get; set; }

[JsonPropertyName("top_posters")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }

[JsonPropertyName("top_admins")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }

[JsonPropertyName("top_inviters")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
