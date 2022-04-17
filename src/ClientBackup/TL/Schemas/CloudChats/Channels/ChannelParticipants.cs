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
	public partial class ChannelParticipants : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1699676497; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public int Count { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChannelParticipants (int count,List<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase> participants,List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Count = count;
Participants = participants;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal ChannelParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Count);
var checkparticipants = 			writer.WriteVector(Participants, false);
if(checkparticipants.IsError){
 return checkparticipants; 
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
			var trycount = reader.ReadInt32();
if(trycount.IsError){
return ReadResult<IObject>.Move(trycount);
}
Count = trycount.Value;
			var tryparticipants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryparticipants.IsError){
return ReadResult<IObject>.Move(tryparticipants);
}
Participants = tryparticipants.Value;
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
		    return "channels.channelParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}