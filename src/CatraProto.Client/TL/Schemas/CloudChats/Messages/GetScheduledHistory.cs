using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetScheduledHistory : IMethod
	{
		public static int ConstructorId { get; } = -490575781;
		public InputPeerBase Peer { get; set; }
		public int Hash { get; set; }

		public Type Type { get; init; } = typeof(MessagesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Hash);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Hash = reader.Read<int>();
		}
	}
}