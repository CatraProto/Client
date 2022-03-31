using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class GroupCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1636664659; }
        
[Newtonsoft.Json.JsonProperty("call")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("participants_next_offset")]
		public sealed override string ParticipantsNextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public GroupCall (CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase call,IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants,string participantsNextOffset,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Call = call;
Participants = participants;
ParticipantsNextOffset = participantsNextOffset;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal GroupCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Call);
			writer.Write(Participants);
			writer.Write(ParticipantsNextOffset);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Call = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase>();
			Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
			ParticipantsNextOffset = reader.Read<string>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "phone.groupCall";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}