using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class BroadcastStatsBase : IObject
    {

[JsonPropertyName("period")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

[JsonPropertyName("followers")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Followers { get; set; }

[JsonPropertyName("views_per_post")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase ViewsPerPost { get; set; }

[JsonPropertyName("shares_per_post")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase SharesPerPost { get; set; }

[JsonPropertyName("enabled_notifications")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase EnabledNotifications { get; set; }

[JsonPropertyName("growth_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

[JsonPropertyName("followers_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase FollowersGraph { get; set; }

[JsonPropertyName("mute_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MuteGraph { get; set; }

[JsonPropertyName("top_hours_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

[JsonPropertyName("interactions_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase InteractionsGraph { get; set; }

[JsonPropertyName("iv_interactions_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase IvInteractionsGraph { get; set; }

[JsonPropertyName("views_by_source_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsBySourceGraph { get; set; }

[JsonPropertyName("new_followers_by_source_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewFollowersBySourceGraph { get; set; }

[JsonPropertyName("languages_graph")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

[JsonPropertyName("recent_message_interactions")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> RecentMessageInteractions { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
