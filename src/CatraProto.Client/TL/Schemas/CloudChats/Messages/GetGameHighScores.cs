using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetGameHighScores : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>
	{


        public static int ConstructorId { get; } = -400399203;

		public InputPeerBase Peer { get; set; }
		public int Id { get; set; }
		public InputUserBase UserId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(UserId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();

		}
	}
}