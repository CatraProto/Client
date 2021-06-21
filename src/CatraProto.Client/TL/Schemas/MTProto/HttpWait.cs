using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class HttpWait : IMethod
	{
		public static int ConstructorId { get; } = -1835453025;
		public int MaxDelay { get; set; }
		public int WaitAfter { get; set; }
		public int MaxWait { get; set; }

		public Type Type { get; init; } = typeof(HttpWaitBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxDelay);
			writer.Write(WaitAfter);
			writer.Write(MaxWait);
		}

		public void Deserialize(Reader reader)
		{
			MaxDelay = reader.Read<int>();
			WaitAfter = reader.Read<int>();
			MaxWait = reader.Read<int>();
		}
	}
}