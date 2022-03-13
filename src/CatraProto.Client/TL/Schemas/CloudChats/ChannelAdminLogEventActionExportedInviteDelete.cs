using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionExportedInviteDelete : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1515256996; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionExportedInviteDelete (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite)
{
 Invite = invite;
 
}
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteDelete() 
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
		    return "channelAdminLogEventActionExportedInviteDelete";
		}
	}
}