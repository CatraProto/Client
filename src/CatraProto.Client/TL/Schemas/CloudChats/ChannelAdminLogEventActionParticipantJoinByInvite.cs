using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantJoinByInvite : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1557846647; }
        
[Newtonsoft.Json.JsonProperty("invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionParticipantJoinByInvite (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite)
{
 Invite = invite;
 
}
#nullable disable
        internal ChannelAdminLogEventActionParticipantJoinByInvite() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Invite);

		}

		public override void Deserialize(Reader reader)
		{
			Invite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();

		}
		
		public override string ToString()
		{
		    return "channelAdminLogEventActionParticipantJoinByInvite";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}