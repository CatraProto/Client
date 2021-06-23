using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ReportPeer : IMethod
	{
		public static int ConstructorId { get; } = -1374118561;
		public InputPeerBase Peer { get; set; }
		public ReportReasonBase Reason { get; set; }

		public Type Type { get; init; } = typeof(bool);
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
			writer.Write(Reason);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Reason = reader.Read<ReportReasonBase>();
		}
	}
}