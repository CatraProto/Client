using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantToggleAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -714643696; }
        
[Newtonsoft.Json.JsonProperty("prev_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("new_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionParticipantToggleAdmin (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase prevParticipant,CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase newParticipant)
{
 PrevParticipant = prevParticipant;
NewParticipant = newParticipant;
 
}
#nullable disable
        internal ChannelAdminLogEventActionParticipantToggleAdmin() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PrevParticipant);
			writer.Write(NewParticipant);

		}

		public override void Deserialize(Reader reader)
		{
			PrevParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			NewParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionParticipantToggleAdmin";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}