using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantMute : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -115071790; }
        
[Newtonsoft.Json.JsonProperty("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase Participant { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionParticipantMute (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase participant)
{
 Participant = participant;
 
}
#nullable disable
        internal ChannelAdminLogEventActionParticipantMute() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Participant);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionParticipantMute";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}