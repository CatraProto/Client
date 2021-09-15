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


        public static int StaticConstructorId { get => 1421875280; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("default_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}