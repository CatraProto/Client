using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputDialogPeer : CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase
	{


        public static int StaticConstructorId { get => -55902537; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }


        #nullable enable
 public InputDialogPeer (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
{
 Peer = peer;
 
}
#nullable disable
        internal InputDialogPeer() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peer);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();

		}
				
		public override string ToString()
		{
		    return "inputDialogPeer";
		}
	}
}