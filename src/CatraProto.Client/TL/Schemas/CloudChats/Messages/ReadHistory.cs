using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadHistory : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>
	{


        public static int ConstructorId { get; } = 238054714;

		public InputPeerBase Peer { get; set; }
		public int MaxId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MaxId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MaxId = reader.Read<int>();

		}
	}
}