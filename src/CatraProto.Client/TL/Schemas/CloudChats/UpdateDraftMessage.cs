using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDraftMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -299124375; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("draft")]
		public CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase Draft { get; set; }


        #nullable enable
 public UpdateDraftMessage (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase draft)
{
 Peer = peer;
Draft = draft;
 
}
#nullable disable
        internal UpdateDraftMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Draft);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Draft = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase>();

		}
				
		public override string ToString()
		{
		    return "updateDraftMessage";
		}
	}
}