using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerLocated : UpdateBase
	{


        public static int ConstructorId { get; } = -1263546448;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase> Peers { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peers);

		}

		public override void Deserialize(Reader reader)
		{
			Peers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase>();

		}
	}
}