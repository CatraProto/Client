using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPeerDialogs : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -462373635; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("peers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Peers { get; set; }

        
        #nullable enable
 public GetPeerDialogs (IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers)
{
 Peers = peers;
 
}
#nullable disable
                
        internal GetPeerDialogs() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Peers);

		}

		public void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();

		}
		
		public override string ToString()
		{
		    return "messages.getPeerDialogs";
		}
	}
}