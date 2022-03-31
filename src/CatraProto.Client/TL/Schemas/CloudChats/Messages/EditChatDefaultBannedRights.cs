using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class EditChatDefaultBannedRights : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1517917375; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }

        
        #nullable enable
 public EditChatDefaultBannedRights (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights)
{
 Peer = peer;
BannedRights = bannedRights;
 
}
#nullable disable
                
        internal EditChatDefaultBannedRights() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(BannedRights);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			BannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();

		}

		public override string ToString()
		{
		    return "messages.editChatDefaultBannedRights";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}