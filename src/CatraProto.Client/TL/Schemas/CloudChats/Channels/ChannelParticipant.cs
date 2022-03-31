using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChannelParticipant (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase participant,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Participant);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

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