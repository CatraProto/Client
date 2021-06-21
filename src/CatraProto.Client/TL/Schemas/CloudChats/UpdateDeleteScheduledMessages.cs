using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDeleteScheduledMessages : UpdateBase
	{


        public static int ConstructorId { get; } = -1870238482;
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public IList<int> Messages { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Messages = reader.ReadVector<int>();

		}
	}
}