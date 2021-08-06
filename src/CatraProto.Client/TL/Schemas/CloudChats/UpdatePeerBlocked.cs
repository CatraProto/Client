using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 610945826; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("peer_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[JsonPropertyName("blocked")]
		public bool Blocked { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PeerId);
			writer.Write(Blocked);

		}

		public override void Deserialize(Reader reader)
		{
			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Blocked = reader.Read<bool>();

		}
	}
}