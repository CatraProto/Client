using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class GroupParticipants : CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -193506890; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public sealed override string NextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public sealed override int Version { get; set; }


        #nullable enable
 public GroupParticipants (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> participants,string nextOffset,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users,int version)
{
 Count = count;
Participants = participants;
NextOffset = nextOffset;
Chats = chats;
Users = users;
Version = version;
 
}
#nullable disable
        internal GroupParticipants() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Participants);
			writer.Write(NextOffset);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
			NextOffset = reader.Read<string>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			Version = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "phone.groupParticipants";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}