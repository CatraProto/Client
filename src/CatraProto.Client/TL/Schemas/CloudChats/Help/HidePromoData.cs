using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class HidePromoData : IMethod
	{
		public static int ConstructorId { get; } = 505748629;
		public InputPeerBase Peer { get; set; }

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
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
		}
	}
}