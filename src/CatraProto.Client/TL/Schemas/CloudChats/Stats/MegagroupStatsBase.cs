using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public abstract class MegagroupStatsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("period")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

        [Newtonsoft.Json.JsonProperty("members")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Members { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("viewers")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Viewers { get; set; }

        [Newtonsoft.Json.JsonProperty("posters")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Posters { get; set; }

        [Newtonsoft.Json.JsonProperty("growth_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("members_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MembersGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("new_members_by_source_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewMembersBySourceGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("languages_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("messages_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MessagesGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("actions_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ActionsGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_hours_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("weekdays_graph")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase WeekdaysGraph { get; set; }

        [Newtonsoft.Json.JsonProperty("top_posters")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }

        [Newtonsoft.Json.JsonProperty("top_admins")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }

        [Newtonsoft.Json.JsonProperty("top_inviters")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

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