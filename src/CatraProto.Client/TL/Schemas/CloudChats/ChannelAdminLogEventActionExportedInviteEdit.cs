using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionExportedInviteEdit : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -384910503; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prev_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase PrevInvite { get; set; }

[Newtonsoft.Json.JsonProperty("new_invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase NewInvite { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionExportedInviteEdit (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase prevInvite,CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase newInvite)
{
 PrevInvite = prevInvite;
NewInvite = newInvite;
 
}
#nullable disable
        internal ChannelAdminLogEventActionExportedInviteEdit() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PrevInvite);
			writer.Write(NewInvite);

		}

		public override void Deserialize(Reader reader)
		{
			PrevInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			NewInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionExportedInviteEdit";
		}
	}
}