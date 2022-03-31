using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantVolume : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1048537159; }
        
[Newtonsoft.Json.JsonProperty("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase Participant { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionParticipantVolume (CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase participant)
{
 Participant = participant;
 
}
#nullable disable
        internal ChannelAdminLogEventActionParticipantVolume() 
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
		    return "channelAdminLogEventActionParticipantVolume";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}