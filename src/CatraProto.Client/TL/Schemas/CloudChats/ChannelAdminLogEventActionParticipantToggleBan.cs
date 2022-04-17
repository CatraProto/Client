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
	public partial class ChannelAdminLogEventActionParticipantToggleBan : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -422036098; }
        
[Newtonsoft.Json.JsonProperty("prev_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("new_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionParticipantToggleBan (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase prevParticipant,CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase newParticipant)
{
 PrevParticipant = prevParticipant;
NewParticipant = newParticipant;
 
}
#nullable disable
        internal ChannelAdminLogEventActionParticipantToggleBan() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkprevParticipant = 			writer.WriteObject(PrevParticipant);
if(checkprevParticipant.IsError){
 return checkprevParticipant; 
}
var checknewParticipant = 			writer.WriteObject(NewParticipant);
if(checknewParticipant.IsError){
 return checknewParticipant; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryprevParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
if(tryprevParticipant.IsError){
return ReadResult<IObject>.Move(tryprevParticipant);
}
PrevParticipant = tryprevParticipant.Value;
			var trynewParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
if(trynewParticipant.IsError){
return ReadResult<IObject>.Move(trynewParticipant);
}
NewParticipant = trynewParticipant.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionParticipantToggleBan";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}