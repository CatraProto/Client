using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class MegagroupStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -276825834; }

        [Newtonsoft.Json.JsonProperty("period")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

        [Newtonsoft.Json.JsonProperty("members")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Members { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("viewers")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Viewers { get; set; }

        [Newtonsoft.Json.JsonProperty("posters")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Posters { get; set; }

        [Newtonsoft.Json.JsonProperty("growth_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("members_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MembersGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("new_members_by_source_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewMembersBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("languages_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("messages_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MessagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("actions_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ActionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_hours_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("weekdays_graph")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase WeekdaysGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_posters")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }

        [Newtonsoft.Json.JsonProperty("top_admins")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }

        [Newtonsoft.Json.JsonProperty("top_inviters")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public MegagroupStats(CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase period, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase members, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase messages, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase viewers, CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase posters, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase growthGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase membersGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase newMembersBySourceGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase languagesGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase messagesGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase actionsGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase topHoursGraph, CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase weekdaysGraph, List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> topPosters, List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> topAdmins, List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> topInviters, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Period = period;
            Members = members;
            Messages = messages;
            Viewers = viewers;
            Posters = posters;
            GrowthGraph = growthGraph;
            MembersGraph = membersGraph;
            NewMembersBySourceGraph = newMembersBySourceGraph;
            LanguagesGraph = languagesGraph;
            MessagesGraph = messagesGraph;
            ActionsGraph = actionsGraph;
            TopHoursGraph = topHoursGraph;
            WeekdaysGraph = weekdaysGraph;
            TopPosters = topPosters;
            TopAdmins = topAdmins;
            TopInviters = topInviters;
            Users = users;

        }
#nullable disable
        internal MegagroupStats()
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
            var checkmembers = writer.WriteObject(Members);
            if (checkmembers.IsError)
            {
                return checkmembers;
            }
            var checkmessages = writer.WriteObject(Messages);
            if (checkmessages.IsError)
            {
                return checkmessages;
            }
            var checkviewers = writer.WriteObject(Viewers);
            if (checkviewers.IsError)
            {
                return checkviewers;
            }
            var checkposters = writer.WriteObject(Posters);
            if (checkposters.IsError)
            {
                return checkposters;
            }
            var checkgrowthGraph = writer.WriteObject(GrowthGraph);
            if (checkgrowthGraph.IsError)
            {
                return checkgrowthGraph;
            }
            var checkmembersGraph = writer.WriteObject(MembersGraph);
            if (checkmembersGraph.IsError)
            {
                return checkmembersGraph;
            }
            var checknewMembersBySourceGraph = writer.WriteObject(NewMembersBySourceGraph);
            if (checknewMembersBySourceGraph.IsError)
            {
                return checknewMembersBySourceGraph;
            }
            var checklanguagesGraph = writer.WriteObject(LanguagesGraph);
            if (checklanguagesGraph.IsError)
            {
                return checklanguagesGraph;
            }
            var checkmessagesGraph = writer.WriteObject(MessagesGraph);
            if (checkmessagesGraph.IsError)
            {
                return checkmessagesGraph;
            }
            var checkactionsGraph = writer.WriteObject(ActionsGraph);
            if (checkactionsGraph.IsError)
            {
                return checkactionsGraph;
            }
            var checktopHoursGraph = writer.WriteObject(TopHoursGraph);
            if (checktopHoursGraph.IsError)
            {
                return checktopHoursGraph;
            }
            var checkweekdaysGraph = writer.WriteObject(WeekdaysGraph);
            if (checkweekdaysGraph.IsError)
            {
                return checkweekdaysGraph;
            }
            var checktopPosters = writer.WriteVector(TopPosters, false);
            if (checktopPosters.IsError)
            {
                return checktopPosters;
            }
            var checktopAdmins = writer.WriteVector(TopAdmins, false);
            if (checktopAdmins.IsError)
            {
                return checktopAdmins;
            }
            var checktopInviters = writer.WriteVector(TopInviters, false);
            if (checktopInviters.IsError)
            {
                return checktopInviters;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
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
            var trymembers = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (trymembers.IsError)
            {
                return ReadResult<IObject>.Move(trymembers);
            }
            Members = trymembers.Value;
            var trymessages = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }
            Messages = trymessages.Value;
            var tryviewers = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (tryviewers.IsError)
            {
                return ReadResult<IObject>.Move(tryviewers);
            }
            Viewers = tryviewers.Value;
            var tryposters = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
            if (tryposters.IsError)
            {
                return ReadResult<IObject>.Move(tryposters);
            }
            Posters = tryposters.Value;
            var trygrowthGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trygrowthGraph.IsError)
            {
                return ReadResult<IObject>.Move(trygrowthGraph);
            }
            GrowthGraph = trygrowthGraph.Value;
            var trymembersGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trymembersGraph.IsError)
            {
                return ReadResult<IObject>.Move(trymembersGraph);
            }
            MembersGraph = trymembersGraph.Value;
            var trynewMembersBySourceGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trynewMembersBySourceGraph.IsError)
            {
                return ReadResult<IObject>.Move(trynewMembersBySourceGraph);
            }
            NewMembersBySourceGraph = trynewMembersBySourceGraph.Value;
            var trylanguagesGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trylanguagesGraph.IsError)
            {
                return ReadResult<IObject>.Move(trylanguagesGraph);
            }
            LanguagesGraph = trylanguagesGraph.Value;
            var trymessagesGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trymessagesGraph.IsError)
            {
                return ReadResult<IObject>.Move(trymessagesGraph);
            }
            MessagesGraph = trymessagesGraph.Value;
            var tryactionsGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryactionsGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryactionsGraph);
            }
            ActionsGraph = tryactionsGraph.Value;
            var trytopHoursGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (trytopHoursGraph.IsError)
            {
                return ReadResult<IObject>.Move(trytopHoursGraph);
            }
            TopHoursGraph = trytopHoursGraph.Value;
            var tryweekdaysGraph = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
            if (tryweekdaysGraph.IsError)
            {
                return ReadResult<IObject>.Move(tryweekdaysGraph);
            }
            WeekdaysGraph = tryweekdaysGraph.Value;
            var trytopPosters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytopPosters.IsError)
            {
                return ReadResult<IObject>.Move(trytopPosters);
            }
            TopPosters = trytopPosters.Value;
            var trytopAdmins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytopAdmins.IsError)
            {
                return ReadResult<IObject>.Move(trytopAdmins);
            }
            TopAdmins = trytopAdmins.Value;
            var trytopInviters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytopInviters.IsError)
            {
                return ReadResult<IObject>.Move(trytopInviters);
            }
            TopInviters = trytopInviters.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stats.megagroupStats";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}