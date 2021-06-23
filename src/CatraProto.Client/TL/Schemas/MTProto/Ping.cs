using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class Ping : IMethod
	{
		public static int ConstructorId { get; } = 2059302892;
		public long PingId { get; set; }

		public Type Type { get; init; } = typeof(PongBase);
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

			writer.Write(PingId);
		}

		public void Deserialize(Reader reader)
		{
			PingId = reader.Read<long>();
		}
	}
}