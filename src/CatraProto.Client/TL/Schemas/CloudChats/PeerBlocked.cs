using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -386039788; }
        
[Newtonsoft.Json.JsonProperty("peer_id")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }


        #nullable enable
 public PeerBlocked (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId,int date)
{
 PeerId = peerId;
Date = date;
 
}
#nullable disable
        internal PeerBlocked() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PeerId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Date = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "peerBlocked";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}