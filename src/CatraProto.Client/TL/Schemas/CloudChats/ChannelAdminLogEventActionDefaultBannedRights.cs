using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionDefaultBannedRights : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 771095562; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prev_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase PrevBannedRights { get; set; }

[Newtonsoft.Json.JsonProperty("new_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase NewBannedRights { get; set; }


        #nullable enable
 public ChannelAdminLogEventActionDefaultBannedRights (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase prevBannedRights,CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase newBannedRights)
{
 PrevBannedRights = prevBannedRights;
NewBannedRights = newBannedRights;
 
}
#nullable disable
        internal ChannelAdminLogEventActionDefaultBannedRights() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PrevBannedRights);
			writer.Write(NewBannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			PrevBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
			NewBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionDefaultBannedRights";
		}
	}
}