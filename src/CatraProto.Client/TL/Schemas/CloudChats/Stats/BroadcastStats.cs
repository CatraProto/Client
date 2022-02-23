using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class BroadcastStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase
    {
        public static int StaticConstructorId
        {
            get => -1107852396;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("period")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

        [Newtonsoft.Json.JsonProperty("followers")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Followers { get; set; }

        [Newtonsoft.Json.JsonProperty("views_per_post")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase ViewsPerPost { get; set; }

        [Newtonsoft.Json.JsonProperty("shares_per_post")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase SharesPerPost { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled_notifications")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase EnabledNotifications { get; set; }

        [Newtonsoft.Json.JsonProperty("growth_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("followers_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase FollowersGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("mute_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MuteGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_hours_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("interactions_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase InteractionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("iv_interactions_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase IvInteractionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("views_by_source_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("new_followers_by_source_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewFollowersBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("languages_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_message_interactions")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> RecentMessageInteractions { get; set; }


    #nullable enable
        public BroadcastStats(CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase period, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase followers, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase viewsPerPost, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase sharesPerPost, CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase enabledNotifications, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase growthGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase followersGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase muteGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase topHoursGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase interactionsGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ivInteractionsGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase viewsBySourceGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase newFollowersBySourceGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase languagesGraph, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> recentMessageInteractions)
        {
            Period = period;
            Followers = followers;
            ViewsPerPost = viewsPerPost;
            SharesPerPost = sharesPerPost;
            EnabledNotifications = enabledNotifications;
            GrowthGraph = growthGraph;
            FollowersGraph = followersGraph;
            MuteGraph = muteGraph;
            TopHoursGraph = topHoursGraph;
            InteractionsGraph = interactionsGraph;
            IvInteractionsGraph = ivInteractionsGraph;
            ViewsBySourceGraph = viewsBySourceGraph;
            NewFollowersBySourceGraph = newFollowersBySourceGraph;
            LanguagesGraph = languagesGraph;
            RecentMessageInteractions = recentMessageInteractions;
        }
    #nullable disable
        internal BroadcastStats()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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
            Period = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase>();
            Followers = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            ViewsPerPost = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            SharesPerPost = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            EnabledNotifications = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase>();
            GrowthGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            FollowersGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            MuteGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            TopHoursGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            InteractionsGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            IvInteractionsGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            ViewsBySourceGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            NewFollowersBySourceGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            LanguagesGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            RecentMessageInteractions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase>();
        }

        public override string ToString()
        {
            return "stats.broadcastStats";
        }
    }
}