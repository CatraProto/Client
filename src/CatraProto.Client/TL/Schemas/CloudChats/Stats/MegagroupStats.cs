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
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase Period { get; set; }

[Newtonsoft.Json.JsonProperty("members")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Members { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Messages { get; set; }

[Newtonsoft.Json.JsonProperty("viewers")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Viewers { get; set; }

[Newtonsoft.Json.JsonProperty("posters")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase Posters { get; set; }

[Newtonsoft.Json.JsonProperty("growth_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase GrowthGraph { get; set; }

[Newtonsoft.Json.JsonProperty("members_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MembersGraph { get; set; }

[Newtonsoft.Json.JsonProperty("new_members_by_source_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase NewMembersBySourceGraph { get; set; }

[Newtonsoft.Json.JsonProperty("languages_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase LanguagesGraph { get; set; }

[Newtonsoft.Json.JsonProperty("messages_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase MessagesGraph { get; set; }

[Newtonsoft.Json.JsonProperty("actions_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase ActionsGraph { get; set; }

[Newtonsoft.Json.JsonProperty("top_hours_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase TopHoursGraph { get; set; }

[Newtonsoft.Json.JsonProperty("weekdays_graph")]
		public override CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase WeekdaysGraph { get; set; }

[Newtonsoft.Json.JsonProperty("top_posters")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopPosterBase> TopPosters { get; set; }

[Newtonsoft.Json.JsonProperty("top_admins")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase> TopAdmins { get; set; }

[Newtonsoft.Json.JsonProperty("top_inviters")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase> TopInviters { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
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