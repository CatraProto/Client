using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkparticipant = 			writer.WriteObject(Participant);
if(checkparticipant.IsError){
 return checkparticipant; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryparticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
if(tryparticipant.IsError){
return ReadResult<IObject>.Move(tryparticipant);
}
Participant = tryparticipant.Value;
return new ReadResult<IObject>(this);

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