using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class DeleteParticipantHistory : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 913655003; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Participant { get; set; }

        
        #nullable enable
 public DeleteParticipantHistory (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant)
{
 Channel = channel;
Participant = participant;
 
}
#nullable disable
                
        internal DeleteParticipantHistory() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkchannel = 			writer.WriteObject(Channel);
if(checkchannel.IsError){
 return checkchannel; 
}
var checkparticipant = 			writer.WriteObject(Participant);
if(checkparticipant.IsError){
 return checkparticipant; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
if(trychannel.IsError){
return ReadResult<IObject>.Move(trychannel);
}
Channel = trychannel.Value;
			var tryparticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(tryparticipant.IsError){
return ReadResult<IObject>.Move(tryparticipant);
}
Participant = tryparticipant.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "channels.deleteParticipantHistory";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}