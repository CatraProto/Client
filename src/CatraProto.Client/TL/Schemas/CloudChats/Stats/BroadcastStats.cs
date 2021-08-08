using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class BroadcastStats : BroadcastStatsBase
	{


        public static int StaticConstructorId { get => -1107852396; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("period")]
		public override StatsDateRangeDaysBase Period { get; set; }

[JsonPropertyName("followers")]
		public override StatsAbsValueAndPrevBase Followers { get; set; }

[JsonPropertyName("views_per_post")]
		public override StatsAbsValueAndPrevBase ViewsPerPost { get; set; }

[JsonPropertyName("shares_per_post")]
		public override StatsAbsValueAndPrevBase SharesPerPost { get; set; }

[JsonPropertyName("enabled_notifications")]
		public override StatsPercentValueBase EnabledNotifications { get; set; }

[JsonPropertyName("growth_graph")]
		public override StatsGraphBase GrowthGraph { get; set; }

[JsonPropertyName("followers_graph")]
		public override StatsGraphBase FollowersGraph { get; set; }

[JsonPropertyName("mute_graph")]
		public override StatsGraphBase MuteGraph { get; set; }

[JsonPropertyName("top_hours_graph")]
		public override StatsGraphBase TopHoursGraph { get; set; }

[JsonPropertyName("interactions_graph")]
		public override StatsGraphBase InteractionsGraph { get; set; }

[JsonPropertyName("iv_interactions_graph")]
		public override StatsGraphBase IvInteractionsGraph { get; set; }

[JsonPropertyName("views_by_source_graph")]
		public override StatsGraphBase ViewsBySourceGraph { get; set; }

[JsonPropertyName("new_followers_by_source_graph")]
		public override StatsGraphBase NewFollowersBySourceGraph { get; set; }

[JsonPropertyName("languages_graph")]
		public override StatsGraphBase LanguagesGraph { get; set; }

[JsonPropertyName("recent_message_interactions")]
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