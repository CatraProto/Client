using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatDefaultBannedRights : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1421875280; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("default_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }


        #nullable enable
 public UpdateChatDefaultBannedRights (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase defaultBannedRights,int version)
{
 Peer = peer;
DefaultBannedRights = defaultBannedRights;
Version = version;
 
}
#nullable disable
        internal UpdateChatDefaultBannedRights() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(DefaultBannedRights);
			writer.Write(Version);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			DefaultBannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
			Version = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateChatDefaultBannedRights";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}