using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class BroadcastStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1107852396; }

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
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> RecentMessageInteractions { get; set; }


#nullable enable
        public BroadcastStats(CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase period, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase followers, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase viewsPerPost, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase sharesPerPost, CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase enabledNotifications, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase growthGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase followersGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase muteGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase topHoursGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase interactionsGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ivInteractionsGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase viewsBySourceGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase newFollowersBySourceGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase languagesGraph, List<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase> recentMessageInteractions)
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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkperiod = writer.WriteObject(Period);
            if (checkperiod.IsError)
            {
                return checkperiod;
            }

            var checkfollowers = writer.WriteObject(Followers);
            if (checkfollowers.IsError)
            {
                return checkfollowers;
            }

            var checkviewsPerPost = writer.WriteObject(ViewsPerPost);
            if (checkviewsPerPost.IsError)
            {
                return checkviewsPerPost;
            }

            var checksharesPerPost = writer.WriteObject(SharesPerPost);
            if (checksharesPerPost.IsError)
            {
                return checksharesPerPost;
            }

            var checkenabledNotifications = writer.WriteObject(EnabledNotifications);
            if (checkenabledNotifications.IsError)
            {
                return checkenabledNotifications;
            }

            var checkgrowthGraph = writer.WriteObject(GrowthGraph);
            if (checkgrowthGraph.IsError)
            {
                return checkgrowthGraph;
            }

            var checkfollowersGraph = writer.WriteObject(FollowersGraph);
            if (checkfollowersGraph.IsError)
            {
                return checkfollowersGraph;
            }

            var checkmuteGraph = writer.WriteObject(MuteGraph);
            if (checkmuteGraph.IsError)
            {
                return checkmuteGraph;
            }

            var checktopHoursGraph = writer.WriteObject(TopHoursGraph);
            if (checktopHoursGraph.IsError)
            {
                return checktopHoursGraph;
            }

            var checkinteractionsGraph = writer.WriteObject(InteractionsGraph);
            if (checkinteractionsGraph.IsError)
            {
                return checkinteractionsGraph;
            }

            var checkivInteractionsGraph = writer.WriteObject(IvInteractionsGraph);
            if (checkivInteractionsGraph.IsError)
            {
                return checkivInteractionsGraph;
            }

            var checkviewsBySourceGraph = writer.WriteObject(ViewsBySourceGraph);
            if (checkviewsBySourceGraph.IsError)
            {
                return checkviewsBySourceGraph;
            }

            var checknewFollowersBySourceGraph = writer.WriteObject(NewFollowersBySourceGraph);
            if (checknewFollowersBySourceGraph.IsError)
            {
                return checknewFollowersBySourceGraph;
            }

            var checklanguagesGraph = writer.WriteObject(LanguagesGraph);
            if (checklanguagesGraph.IsError)
            {
                return checklanguagesGraph;
            }

            var checkrecentMessageInteractions = writer.WriteVector(RecentMessageInteractions, false);
            if (checkrecentMessageInteractions.IsError)
            {
                return checkrecentMessageInteractions;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryperiod = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase>();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }

            Period = tryperiod.Value;
            var tryfollowers = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (tryfollowers.IsError)
            {
                return ReadResult<IObject>.Move(tryfollowers);
            }

            Followers = tryfollowers.Value;
            var tryviewsPerPost = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (tryviewsPerPost.IsError)
            {
                return ReadResult<IObject>.Move(tryviewsPerPost);
            }

            ViewsPerPost = tryviewsPerPost.Value;
            var trysharesPerPost = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (trysharesPerPost.IsError)
            {
                return ReadResult<IObject>.Move(trysharesPerPost);
            }

            SharesPerPost = trysharesPerPost.Value;
            var tryenabledNotifications = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase>();
            if (tryenabledNotifications.IsError)
            {
                return ReadResult<IObject>.Move(tryenabledNotifications);
            }

            EnabledNotifications = tryenabledNotifications.Value;
            var trygrowthGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trygrowthGraph.IsError)
            {
                return ReadResult<IObject>.Move(trygrowthGraph);
            }

            GrowthGraph = trygrowthGraph.Value;
            var tryfollowersGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryfollowersGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryfollowersGraph);
            }

            FollowersGraph = tryfollowersGraph.Value;
            var trymuteGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trymuteGraph.IsError)
            {
                return ReadResult<IObject>.Move(trymuteGraph);
            }

            MuteGraph = trymuteGraph.Value;
            var trytopHoursGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trytopHoursGraph.IsError)
            {
                return ReadResult<IObject>.Move(trytopHoursGraph);
            }

            TopHoursGraph = trytopHoursGraph.Value;
            var tryinteractionsGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryinteractionsGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryinteractionsGraph);
            }

            InteractionsGraph = tryinteractionsGraph.Value;
            var tryivInteractionsGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryivInteractionsGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryivInteractionsGraph);
            }

            IvInteractionsGraph = tryivInteractionsGraph.Value;
            var tryviewsBySourceGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryviewsBySourceGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryviewsBySourceGraph);
            }

            ViewsBySourceGraph = tryviewsBySourceGraph.Value;
            var trynewFollowersBySourceGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trynewFollowersBySourceGraph.IsError)
            {
                return ReadResult<IObject>.Move(trynewFollowersBySourceGraph);
            }

            NewFollowersBySourceGraph = trynewFollowersBySourceGraph.Value;
            var trylanguagesGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trylanguagesGraph.IsError)
            {
                return ReadResult<IObject>.Move(trylanguagesGraph);
            }

            LanguagesGraph = trylanguagesGraph.Value;
            var tryrecentMessageInteractions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrecentMessageInteractions.IsError)
            {
                return ReadResult<IObject>.Move(tryrecentMessageInteractions);
            }

            RecentMessageInteractions = tryrecentMessageInteractions.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "stats.broadcastStats";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BroadcastStats();
            var clonePeriod = (CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase?)Period.Clone();
            if (clonePeriod is null)
            {
                return null;
            }

            newClonedObject.Period = clonePeriod;
            var cloneFollowers = (CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase?)Followers.Clone();
            if (cloneFollowers is null)
            {
                return null;
            }

            newClonedObject.Followers = cloneFollowers;
            var cloneViewsPerPost = (CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase?)ViewsPerPost.Clone();
            if (cloneViewsPerPost is null)
            {
                return null;
            }

            newClonedObject.ViewsPerPost = cloneViewsPerPost;
            var cloneSharesPerPost = (CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase?)SharesPerPost.Clone();
            if (cloneSharesPerPost is null)
            {
                return null;
            }

            newClonedObject.SharesPerPost = cloneSharesPerPost;
            var cloneEnabledNotifications = (CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase?)EnabledNotifications.Clone();
            if (cloneEnabledNotifications is null)
            {
                return null;
            }

            newClonedObject.EnabledNotifications = cloneEnabledNotifications;
            var cloneGrowthGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)GrowthGraph.Clone();
            if (cloneGrowthGraph is null)
            {
                return null;
            }

            newClonedObject.GrowthGraph = cloneGrowthGraph;
            var cloneFollowersGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)FollowersGraph.Clone();
            if (cloneFollowersGraph is null)
            {
                return null;
            }

            newClonedObject.FollowersGraph = cloneFollowersGraph;
            var cloneMuteGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)MuteGraph.Clone();
            if (cloneMuteGraph is null)
            {
                return null;
            }

            newClonedObject.MuteGraph = cloneMuteGraph;
            var cloneTopHoursGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)TopHoursGraph.Clone();
            if (cloneTopHoursGraph is null)
            {
                return null;
            }

            newClonedObject.TopHoursGraph = cloneTopHoursGraph;
            var cloneInteractionsGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)InteractionsGraph.Clone();
            if (cloneInteractionsGraph is null)
            {
                return null;
            }

            newClonedObject.InteractionsGraph = cloneInteractionsGraph;
            var cloneIvInteractionsGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)IvInteractionsGraph.Clone();
            if (cloneIvInteractionsGraph is null)
            {
                return null;
            }

            newClonedObject.IvInteractionsGraph = cloneIvInteractionsGraph;
            var cloneViewsBySourceGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)ViewsBySourceGraph.Clone();
            if (cloneViewsBySourceGraph is null)
            {
                return null;
            }

            newClonedObject.ViewsBySourceGraph = cloneViewsBySourceGraph;
            var cloneNewFollowersBySourceGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)NewFollowersBySourceGraph.Clone();
            if (cloneNewFollowersBySourceGraph is null)
            {
                return null;
            }

            newClonedObject.NewFollowersBySourceGraph = cloneNewFollowersBySourceGraph;
            var cloneLanguagesGraph = (CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase?)LanguagesGraph.Clone();
            if (cloneLanguagesGraph is null)
            {
                return null;
            }

            newClonedObject.LanguagesGraph = cloneLanguagesGraph;
            newClonedObject.RecentMessageInteractions = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase>();
            foreach (var recentMessageInteractions in RecentMessageInteractions)
            {
                var clonerecentMessageInteractions = (CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase?)recentMessageInteractions.Clone();
                if (clonerecentMessageInteractions is null)
                {
                    return null;
                }

                newClonedObject.RecentMessageInteractions.Add(clonerecentMessageInteractions);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BroadcastStats castedOther)
            {
                return true;
            }

            if (Period.Compare(castedOther.Period))
            {
                return true;
            }

            if (Followers.Compare(castedOther.Followers))
            {
                return true;
            }

            if (ViewsPerPost.Compare(castedOther.ViewsPerPost))
            {
                return true;
            }

            if (SharesPerPost.Compare(castedOther.SharesPerPost))
            {
                return true;
            }

            if (EnabledNotifications.Compare(castedOther.EnabledNotifications))
            {
                return true;
            }

            if (GrowthGraph.Compare(castedOther.GrowthGraph))
            {
                return true;
            }

            if (FollowersGraph.Compare(castedOther.FollowersGraph))
            {
                return true;
            }

            if (MuteGraph.Compare(castedOther.MuteGraph))
            {
                return true;
            }

            if (TopHoursGraph.Compare(castedOther.TopHoursGraph))
            {
                return true;
            }

            if (InteractionsGraph.Compare(castedOther.InteractionsGraph))
            {
                return true;
            }

            if (IvInteractionsGraph.Compare(castedOther.IvInteractionsGraph))
            {
                return true;
            }

            if (ViewsBySourceGraph.Compare(castedOther.ViewsBySourceGraph))
            {
                return true;
            }

            if (NewFollowersBySourceGraph.Compare(castedOther.NewFollowersBySourceGraph))
            {
                return true;
            }

            if (LanguagesGraph.Compare(castedOther.LanguagesGraph))
            {
                return true;
            }

            var recentMessageInteractionssize = castedOther.RecentMessageInteractions.Count;
            if (recentMessageInteractionssize != RecentMessageInteractions.Count)
            {
                return true;
            }

            for (var i = 0; i < recentMessageInteractionssize; i++)
            {
                if (castedOther.RecentMessageInteractions[i].Compare(RecentMessageInteractions[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}