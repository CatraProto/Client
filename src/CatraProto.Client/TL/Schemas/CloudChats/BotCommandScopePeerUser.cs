using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotCommandScopePeerUser : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 169026035; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


        #nullable enable
 public BotCommandScopePeerUser (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
{
 Peer = peer;
UserId = userId;
 
}
#nullable disable
        internal BotCommandScopePeerUser() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
		
		public override string ToString()
		{
		    return "botCommandScopePeerUser";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}