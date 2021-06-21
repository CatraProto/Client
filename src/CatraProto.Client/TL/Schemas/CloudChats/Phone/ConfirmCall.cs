using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class ConfirmCall : IMethod
	{
		public static int ConstructorId { get; } = 788404002;
		public InputPhoneCallBase Peer { get; set; }
		public byte[] GA { get; set; }
		public long KeyFingerprint { get; set; }
		public PhoneCallProtocolBase Protocol { get; set; }

		public Type Type { get; init; } = typeof(PhoneCallBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(GA);
			writer.Write(KeyFingerprint);
			writer.Write(Protocol);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPhoneCallBase>();
			GA = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
		}
	}
}