using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadHistoryOutbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 791617983; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("max_id")]
		public int MaxId { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateReadHistoryOutbox (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,int maxId,int pts,int ptsCount)
{
 Peer = peer;
MaxId = maxId;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateReadHistoryOutbox() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MaxId);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			MaxId = reader.Read<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateReadHistoryOutbox";
		}
	}
}