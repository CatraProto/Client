using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPeerDialogs : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -462373635; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("peers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Peers { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peers);

		}

		public void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();

		}
	}
}