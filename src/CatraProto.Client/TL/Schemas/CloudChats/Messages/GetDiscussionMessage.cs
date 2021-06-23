using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetDiscussionMessage : IMethod
	{
		public static int ConstructorId { get; } = 1147761405;
		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }

		public Type Type { get; init; } = typeof(DiscussionMessageBase);
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
			writer.Write(MsgId);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
		}
	}
}