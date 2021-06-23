using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendScreenshotNotification : IMethod
	{
		public static int ConstructorId { get; } = -914493408;
		public InputPeerBase Peer { get; set; }
		public int ReplyToMsgId { get; set; }
		public long RandomId { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
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
			writer.Write(ReplyToMsgId);
			writer.Write(RandomId);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			ReplyToMsgId = reader.Read<int>();
			RandomId = reader.Read<long>();
		}
	}
}