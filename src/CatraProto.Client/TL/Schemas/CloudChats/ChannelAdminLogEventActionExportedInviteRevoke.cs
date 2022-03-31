using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionExportedInviteRevoke : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1091179342; }
        
[Newtonsoft.Json.JsonProperty("invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionExportedInviteRevoke (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite)
{
 Invite = invite;
 
}
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteRevoke() 
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
		    return "channelAdminLogEventActionExportedInviteRevoke";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}