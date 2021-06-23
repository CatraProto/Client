using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetGameHighScores : IMethod
	{
		public static int ConstructorId { get; } = -400399203;
		public InputPeerBase Peer { get; set; }
		public int Id { get; set; }
		public InputUserBase UserId { get; set; }

		public Type Type { get; init; } = typeof(HighScoresBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

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