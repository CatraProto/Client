using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotChatInviteRequester : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 299870598; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public string About { get; set; }

[Newtonsoft.Json.JsonProperty("invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }


        #nullable enable
 public UpdateBotChatInviteRequester (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int date,long userId,string about,CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite,int qts)
{
 Peer = peer;
Date = date;
UserId = userId;
About = about;
Invite = invite;
Qts = qts;
 
}
#nullable disable
        internal UpdateBotChatInviteRequester() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Date);
			writer.Write(UserId);
			writer.Write(About);
			writer.Write(Invite);
			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Date = reader.Read<int>();
			UserId = reader.Read<long>();
			About = reader.Read<string>();
			Invite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			Qts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateBotChatInviteRequester";
		}
	}
}