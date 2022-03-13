using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class MegagroupStats : CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase
	{


        public static int StaticConstructorId { get => -276825834; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
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
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }

[Newtonsoft.Json.JsonProperty("top_admins")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }

[Newtonsoft.Json.JsonProperty("top_inviters")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public MegagroupStats (CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase period,CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase members,CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase messages,CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase viewers,CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase posters,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase growthGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase membersGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase newMembersBySourceGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase languagesGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase messagesGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase actionsGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase topHoursGraph,CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase weekdaysGraph,IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> topPosters,IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> topAdmins,IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> topInviters,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Period = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase>();
			Members = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
			Messages = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
			Viewers = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
			Posters = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase>();
			GrowthGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			MembersGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			NewMembersBySourceGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			LanguagesGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			MessagesGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			ActionsGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			TopHoursGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			WeekdaysGraph = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>();
			TopPosters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase>();
			TopAdmins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase>();
			TopInviters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "stats.megagroupStats";
		}
	}
}