using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class ReceivedCall : IMethod
	{
		public static int ConstructorId { get; } = 399855457;
		public InputPhoneCallBase Peer { get; set; }

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
			Peer = reader.Read<InputPhoneCallBase>();
		}
	}
}