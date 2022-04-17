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
	public partial class ChannelParticipant : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -541588713; }
        
[Newtonsoft.Json.JsonProperty("participant")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase Participant { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChannelParticipant (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase participant,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Participant = participant;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal ChannelParticipant() 
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
var checkchats = 			writer.WriteVector(Chats, false);
if(checkchats.IsError){
 return checkchats; 
}
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryparticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
if(tryparticipant.IsError){
return ReadResult<IObject>.Move(tryparticipant);
}
Participant = tryparticipant.Value;
			var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trychats.IsError){
return ReadResult<IObject>.Move(trychats);
}
Chats = trychats.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "channels.channelParticipant";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}