using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class BroadcastStatsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("period")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

        [Newtonsoft.Json.JsonProperty("followers")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Followers { get; set; }

        [Newtonsoft.Json.JsonProperty("views_per_post")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase ViewsPerPost { get; set; }

        [Newtonsoft.Json.JsonProperty("shares_per_post")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase SharesPerPost { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled_notifications")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase EnabledNotifications { get; set; }

        [Newtonsoft.Json.JsonProperty("growth_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("followers_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase FollowersGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("mute_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MuteGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_hours_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("interactions_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase InteractionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("iv_interactions_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase IvInteractionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("views_by_source_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ViewsBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("new_followers_by_source_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewFollowersBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("languages_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_message_interactions")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> RecentMessageInteractions { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}