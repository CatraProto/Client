using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 610945826; }
        
[Newtonsoft.Json.JsonProperty("peer_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("blocked")]
		public bool Blocked { get; set; }


        #nullable enable
 public UpdatePeerBlocked (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId,bool blocked)
{
 PeerId = peerId;
Blocked = blocked;
 
}
#nullable disable
        internal UpdatePeerBlocked() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PeerId);
			writer.Write(Blocked);

		}

		public override void Deserialize(Reader reader)
		{
			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Blocked = reader.Read<bool>();

		}
		
		public override string ToString()
		{
		    return "updatePeerBlocked";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}